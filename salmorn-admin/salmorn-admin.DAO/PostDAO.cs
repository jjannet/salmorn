using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.DAO
{
    public class PostDAO : BaseDAO
    {
        public PostDAO() : base()
        {
        }

        public IEnumerable<T_Post> getPosts()
        {
            return context.T_Post;//.ToList();
        }

        public T_Post getPost(int id)
        {
            return context.T_Post.Where(m => m.id == id).First();
        }

        public T_Post adddPost(T_Post item)
        {
            context.T_Post.Add(item);
            context.SaveChanges();
            return item;
        }

        public T_Post updatePost(T_Post item)
        {
            var data = context.T_Post.FirstOrDefault(m => m.id == item.id);
            data.title = item.title;
            data.detail = item.detail;
            data.updateBy = item.updateBy;
            data.updateDate = DateTime.Now;
            data.typeId = item.typeId;
            if (data != null)
            {
                context.Entry(data).CurrentValues.SetValues(data);
                context.SaveChanges();
                return data;
            }
            else
            {
                return null;
            }
        }

        public void updatePostActiveWithoutSaveChange(int id, bool isActive)
        {
            var item = context.T_Post.Single(m => m.id == id);
            item.isActive = isActive;
        }

        public void deletePost(int id)
        {
            var v = context.T_Post.Single(m => m.id == id);
            context.T_Post.Remove(v);
            context.SaveChanges();
        }
    }
}
