using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Linq;
using System.Net;
using  Microsoft.SharePoint.Client;

namespace SPColumnPropertyManager
{
    public class ColumnProperyEditor
    {
        //Needed for singleton pattern
        private static ColumnProperyEditor instance;

        private ColumnProperyEditor() 
        {
            _listTitle = "";
        }

        public static ColumnProperyEditor Instance
        {
            get
            {
                //if (instance == null)
                //{
                //    instance = new ColumnProperyEditor();
                //}
                return instance ?? new ColumnProperyEditor();
            }
        }
        
        private ClientContext _ctx;
        private string _listTitle;

        //public ColumnProperyEditor(string url)
        //{
        //    _ctx = new ClientContext(url);
        //}

        
        // Changed the deafult constructor to fit singleton 
        // leaves a vulnerabillity in setting the context url
        public void SetUrl(string url)
        {
            _ctx = new ClientContext(url);
        }
        
        
        public void ChangeCredentials(string userName, string password)
        {
            _ctx.Credentials = new NetworkCredential(userName, password);
        }

        public ListCollection GetListCollection()
        {
            Web web = _ctx.Web;
            _ctx.Load(web.Lists);
            _ctx.ExecuteQuery();

            return web.Lists;
        }

        public FieldCollection GetListFieldCollection(string listName)
        {
            Web web = _ctx.Web;
            List list = web.Lists.GetByTitle(listName);
            _ctx.Load(list.Fields);
            _ctx.ExecuteQuery();

            _listTitle = listName;

            return list.Fields;
        }

        public void SetPropertyValue(string fieldName, string columnProperty, bool value)
        {
            Web web = _ctx.Web;
            List list = web.Lists.GetByTitle(_listTitle);
            Field field = list.Fields.GetByInternalNameOrTitle(fieldName);

            _ctx.Load(field);
            _ctx.ExecuteQuery();

            XElement fieldSchema = XElement.Parse(field.SchemaXml);
            fieldSchema.SetAttributeValue(columnProperty, value.ToString().ToUpper());
            field.SchemaXml = fieldSchema.ToString();
            _ctx.ExecuteQuery();
        }

    }
}
