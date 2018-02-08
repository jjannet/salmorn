using salmorn_admin.DAO;
using salmorn_admin.Models;
using salmorn_admin.Models.Transactions;
using salmorn_admin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.BO
{
    public class PostBO
    {
        private PostDAO dao;
        public PostBO()
        {
            dao = new PostDAO();
        }

        public List<Post> getPostList()
        {
            return (from x in dao.getPosts()
                    select new Post()
                    {
                        author = x.author,
                        isActive = x.isActive,
                        id = x.id,
                        authorId = x.authorId,
                        postType = ConvertToScreenModel.Masters.postType(x.M_PostType),
                        targetDate = x.targetDate,
                        title = x.title,
                        typeId = x.typeId,
                        updateDate = x.updateDate
                    }).ToList();
        }

        public List<Post> getPosts()
        {
            List<Post> datas = new List<Post>();
            var items = dao.getPosts().ToList();
            foreach (var i in items)
            {
                datas.Add(ConvertToScreenModel.Transactions.post(i));
            }

            return datas;
        }

        public Post getPost(int id)
        {
            return ConvertToScreenModel.Transactions.post(dao.getPost(id));
        }

        public Post addPost(Post item)
        {
            T_Post data = new T_Post();
            data.title = item.title;
            data.detail = item.detail;
            data.typeId = item.typeId;
            data.isActive = item.isActive;
            data.author = item.author;
            data.authorId = item.authorId;
            data.targetDate = item.targetDate;
            data.createDate = DateTime.Now;
            data.updateDate = DateTime.Now;
            data.updateBy = item.updateBy;


            return ConvertToScreenModel.Transactions.post(dao.adddPost(data));
        }

        public Post updatePost(Post item)
        {

            T_Post data = new T_Post()
            {
                id = item.id,
                title = item.title,
                detail = item.detail,
                typeId = item.typeId,
                isActive = item.isActive,
                author = item.author,
                authorId = item.authorId,
                targetDate = item.targetDate,
                createDate = item.createDate,
                updateDate = DateTime.Now,
                updateBy = item.updateBy
            };

            return ConvertToScreenModel.Transactions.post(dao.updatePost(data));
        }

        public bool deletePost(Post data)
        {
            try
            {
                dao.deletePost(data.id);
                return true;
            }
            catch (Exception ex)
            {
                JLog.write(LOG_TYPE.ERROR, LOG_POSITION.BO, this, JLog.GetCurrentMethod(), ex);
                return false;
            }
        }

        public bool updatePostActiveFromList(List<Post> datas, bool isActive)
        {
            this.dao.beginTransaction();
            try
            {
                foreach (var d in datas)
                {
                    dao.updatePostActiveWithoutSaveChange(d.id, isActive);
                }

                dao.saveChange();
                dao.commit();
                return true;
            }
            catch (Exception ex)
            {
                this.dao.rollback();
                JLog.write(LOG_TYPE.ERROR, LOG_POSITION.BO, this, JLog.GetCurrentMethod(), ex);
                return false;
            }

        }
    }
}
