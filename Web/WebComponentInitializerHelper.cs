using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.Security;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Shell;

namespace System
{
    public static class WebComponentInitializerHelper
    {
        public static ComponentLink PageLink<TPage>(string securityKey, string imageUrl, uint? order = null)
            where TPage : SgPage
        {
            var name = typeof(TPage).Name;

            return new ComponentLink(
                name,
                $"Links_{name}",
                imageUrl,
                string.IsNullOrWhiteSpace(securityKey) ? SecurityKey.Public : SecurityKey.Of(securityKey),
                typeof(TPage),
                order);
        }

        public static ComponentLink ListLink<TEntity>(string securityKey, string imageUrl, uint? order = null, string viewName = null, string customListPageUrl = null)
            where TEntity : Entity
        {
            viewName = viewName == null ? string.Empty : $"&ViewName={viewName}&TitleMode=view";
            var metaEntity = MetadataService.GetMetaEntity<TEntity>();
            var name = $"{metaEntity.Name}List";

            return new ComponentLink(
                name,
                $"Links_{name}",
                imageUrl,
                $"~/{customListPageUrl ?? "List.aspx"}?ComponentName={metaEntity.Component.Name}&EntityName={metaEntity.Name}{viewName}",
                order,
                string.IsNullOrWhiteSpace(securityKey) ? SecurityKey.Public : SecurityKey.Of(securityKey));
        }
    }
}