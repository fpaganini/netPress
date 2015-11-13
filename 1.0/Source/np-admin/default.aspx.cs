using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace br.com.pgnsoft.netCMS.netPress.np_admin
{

    public partial class _default : System.Web.UI.Page
    {
        public bool? WP_ADMIN
        {
            get
            {
                return (bool?)Session["WP_ADMIN"];
            }
            set
            {
                Session["WP_ADMIN"] = value;
            }
        }


        public bool? WP_NETWORK_ADMIN
        {
            get
            {
                return (bool?)Session["WP_NETWORK_ADMIN"];
            }
            set
            {
                Session["WP_NETWORK_ADMIN"] = value;
            }
        }


        public bool? WP_USER_ADMIN
        {
            get
            {
                return (bool?)Session["WP_USER_ADMIN"];
            }
            set
            {
                Session["WP_USER_ADMIN"] = value;
            }
        }


        public bool? WP_BLOG_ADMIN
        {
            get
            {
                return (bool?)Session["WP_BLOG_ADMIN"];
            }
            set
            {
                Session["WP_BLOG_ADMIN"] = value;
            }
        }


        public bool? WP_LOAD_IMPORTERS
        {
            get
            {
                return (bool?)Session["WP_LOAD_IMPORTERS"];
            }
            set
            {
                Session["WP_LOAD_IMPORTERS"] = value;
            }
        }


        public string ABSPATH
        {
            get
            {
                return (string)Session["ABSPATH"];
            }
            set
            {
                Session["ABSPATH"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (WP_ADMIN == null)
                WP_ADMIN = true;
            if (WP_NETWORK_ADMIN == null)
                WP_NETWORK_ADMIN = false;
            if (WP_USER_ADMIN == null)
                WP_USER_ADMIN = false;

            if (WP_NETWORK_ADMIN == false && WP_USER_ADMIN == false)
                WP_BLOG_ADMIN = true;

            /** Define ABSPATH as this file's directory */
            if (!String.IsNullOrEmpty(Request["import"]) && WP_LOAD_IMPORTERS == null)
                WP_LOAD_IMPORTERS = true;

            ABSPATH = Server.MapPath(HttpRuntime.AppDomainAppPath) + "/";

            /*
             * If np-config.cfg exists in the netPress root, or if it exists in the root and np-settings.cfg
             * doesn't, load np-config.cfg. The secondary check for wp-settings.cfg has the added benefit
             * of avoiding cases where the current directory is a nested installation, e.g. / is netPress(a)
             * and /blog/ is netPress(b).
             *
             * If neither set of conditions is true, initiate loading the setup process.
             */
            if (System.IO.File.Exists(ABSPATH + "np-config.cfg"))
            {
                /** The config file resides in ABSPATH */
                CarregaVariaveis(ABSPATH + "np-config.cfg");
            }
            else if (System.IO.File.Exists(ABSPATH + "np-config.cfg") && !System.IO.File.Exists(ABSPATH + "np-settings.cfg"))
            {
                /** The config file resides one level above ABSPATH but is not part of another install */
                CarregaVariaveis(ABSPATH + "np-config.cfg");
            }
            else {
                // A config file doesn't exist

                //require_once( ABSPATH . WPINC . '/load.php' );

                //Standardize $_SERVER variables across setups.

                //includes.load.wp_fix_server_vars();



            }

        }
    }
}