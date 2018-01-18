using salmorn_admin.BO;
using salmorn_admin.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace salmorn_admin.Controllers
{
    [Authorize]
    public class PostController : BaseController
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        #region Post list screen

        [HttpPost]
        public JsonResult getPostList()
        {
            var datas = new PostBO().getPostList();
            return Json(datas);
        }

        [HttpPost]
        public JsonResult getPostTypes()
        {
            var datas = new PostTypeBO().getPostTypes();
            return Json(datas);
        }

        [HttpPost]
        public JsonResult showPostFromList([System.Web.Http.FromBody] List<Post> datas)
        {
            var res = new PostBO().updatePostActiveFromList(datas, true);
            return Json(res);
        }

        [HttpPost]
        public JsonResult hidePostFromList([System.Web.Http.FromBody] List<Post> datas)
        {
            var res = new PostBO().updatePostActiveFromList(datas, false);
            return Json(res);
        }

        #endregion

        [Route("Post/New")]
        public ActionResult New()
        {
            return View(-1);
        }

        [Route("Post/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View(id);
        }

        #region Post editor screen

        [HttpPost]
        public JsonResult getPostBlank()
        {
            return Json(new Post() { author = User.DisplayName, authorId = User.UserId, isActive = true, typeId = 1, id = -1 } );
        }

        [HttpPost]
        public JsonResult getPost([System.Web.Http.FromBody] int id)
        {
            var data = new PostBO().getPost(id);
            return Json(data);
        }

        [HttpPost]
        public JsonResult updatePost([System.Web.Http.FromBody] Post data)
        {
            data.updateBy = User.UserId;
            var res = new PostBO().updatePost(data);
            return Json(res);
        }

        [HttpPost]
        public JsonResult addPost([System.Web.Http.FromBody] Post data)
        {
            data.authorId = User.UserId;
            data.updateBy = User.UserId;
            var res = new PostBO().addPost(data);
            return Json(res);
        }

        [HttpPost]
        public JsonResult deletePost([System.Web.Http.FromBody] Post data)
        {
            var res = new PostBO().deletePost(data);
            return Json(res);
        }

        #endregion
    }
}