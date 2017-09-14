using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XEngine.Web.DAL;
using XEngine.Web.Models;
//using XEngine.Web.Utility.MenuHelper.Base;
using XEngine.Web.ViewModels;

namespace XEngine.Web.Utility.MenuHelper
{
    public static class MenuHelper
    {

        public static string GetAllMenuHtml(this HtmlHelper helper)
        {
            string allMenuHtml = "";
            // 获取所有的根菜单，依次添加到allMenuHtml中
            MenuViewModel<SysMenu> model = null;
            HtmlBuilder builder = new HtmlBuilder(helper);

            UnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<SysMenu> rootMenus = unitOfWork.SysMenuRepository.Get(filter: m => m.MenuType == MenuTypeOption.Top);
            foreach (var item in rootMenus)
            {
                builder = new HtmlBuilder(helper);
                model = CreateMenuModel(item.Name);
                builder.BuildTreeStruct(model);
                string tempMenu = builder.Build();

                if (string.IsNullOrEmpty(tempMenu))
                {
                    TagBuilder li_tag = new TagBuilder("li");
                    TagBuilder a_tag = new TagBuilder("a");

                    string contentUrl = GenerateContentUrlFromHttpContext(helper);
                    string a_href = GenerateUrlForMenuItem(item, contentUrl);

                    a_tag.Attributes.Add("href", a_href);
                    a_tag.InnerHtml += item.Name;
                    li_tag.InnerHtml = a_tag.ToString();

                    tempMenu = li_tag.ToString();
                }
                allMenuHtml += tempMenu;
            }

            return allMenuHtml;
        }

        #region 生成链接地址
        static string GenerateContentUrlFromHttpContext(HtmlHelper htmlHelper)
        {
            string contentUrl = UrlHelper.GenerateContentUrl("~/", htmlHelper.ViewContext.HttpContext);
            return contentUrl;
        }

        /// <summary>
        /// 生成菜单地址
        /// </summary>
        /// <param name="menuItem"></param>
        /// <param name="contentUrl"></param>
        /// <returns></returns>
        static string GenerateUrlForMenuItem(SysMenu menuItem, string contentUrl)
        {
            var url = contentUrl + menuItem.Controller;
            if (!string.IsNullOrEmpty(menuItem.Action))
            {
                url += "/" + menuItem.Action;
            }
            return url;
        }
        #endregion

        public static string GetMenuHtml(this HtmlHelper helper, string menuName)
        {
            MenuViewModel<SysMenu> model = null;

            HtmlBuilder builder = new HtmlBuilder(helper);

            model = CreateMenuModel(menuName);

            #region MyRegion
            //switch (HelperType)
            //{
            //    case "Menu1":
            //        model = MenuModelTest.CreateModel();
            //        break;

            //    case "Menu2":
            //        model = MenuModel_1.CreateModel();
            //        break;

            //    default:
            //        model = MenuModelTest.CreateModel();
            //        break;
            //}
            #endregion

            builder.BuildTreeStruct(model);
            string menuHtml = builder.Build();
            return menuHtml;
        }


        /// <summary>
        /// 根据根菜单构建此菜单的树形结构
        /// </summary>
        /// <param name="menuName">根菜单名</param>
        /// <returns></returns>
        public static MenuViewModel<SysMenu> CreateMenuModel(string menuName)
        {
            UnitOfWork unitOfWork = new UnitOfWork();

            MenuViewModel<SysMenu> model = new MenuViewModel<SysMenu>();

            // 1. 根据menuName获取开始的根菜单
            SysMenu itemRoot = unitOfWork.SysMenuRepository.Get(filter: m => m.Name == menuName).FirstOrDefault();

            #region MyRegion
            //           var itemRoots = unitOfWork.SysMenuRepository.Get(filter: m => m.MenuType == MenuTypeOption.Top);

            //if (itemRoots!=null)
            //{
            //    foreach (var itemRoot in itemRoots)
            //    {
            //        // 2. 依次添加枝叶菜单
            //        // 2.1 获取itemRoot的所有子菜单
            //        IEnumerable<SysMenu> menus = unitOfWork.SysMenuRepository.Get(filter: m => m.ParentID == itemRoot.ID);
            //        // 2.2 对每个子菜单进行递归循环
            //        foreach (var item in menus)
            //        {
            //            itemRoot.MenuChildren.Add(item);
            //            AddChildNode(item);
            //        }
            //        model.MenuItems.Add(itemRoot);

            //    }
            //}
            #endregion

            if (itemRoot != null)
            {
                // 2. 依次添加枝叶菜单
                // 2.1 获取itemRoot的所有子菜单
                IEnumerable<SysMenu> menus = unitOfWork.SysMenuRepository.Get(filter: m => m.ParentID == itemRoot.ID);
                // 2.2 对每个子菜单进行递归循环
                foreach (var item in menus)
                {
                    itemRoot.MenuChildren.Add(item);
                    AddChildNode(item);
                }
            }

            model.MenuItems.Add(itemRoot);
            return model;
        }

        /// <summary>
        /// 找到menu的所有子成员并添加，递归出调用本身
        /// </summary>
        /// <param name="menu"></param>
        public static void AddChildNode(SysMenu menu)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var menus = unitOfWork.SysMenuRepository.Get(filter: m => m.ParentID == menu.ID);
            foreach (var item in menus)
            {
                menu.MenuChildren.Add(item);
                AddChildNode(item);
            }
        }

    }
}