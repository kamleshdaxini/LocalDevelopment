using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

    public partial class RoleDetails : System.Web.UI.Page
    {

        // Initialization of Public Variables
        public string UserName; // For Logged in username
        public int LoginUser; // For Logged in userId
        public string Ret; // For return message
        int RoleId; // For Role Id 

        /// <summary>
        ///  Page Load Method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // To set Selected accordion open 
            Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
            int Ind = MasterAcc.SelectedIndex;
            int Index = Convert.ToInt16(Session["SrNo"]);
            MasterAcc.SelectedIndex = Index - 1;
            // To select loginuser id and login username
            Login objRole = new Login();
            objRole.Start();
            UserName = objRole.LogedInUser;
            LoginUser = objRole.LoginUser;
            Ret = objRole.Ret;
            if (!Page.IsPostBack)
            {           
                if (Session["RoleId"] != null)
                {
                    CheckRoleId();
                    RoleId = Convert.ToInt32(Session["RoleId"].ToString());
                }              
            }
            else
            {
                if (Session["RoleId"] != null)
                {
                    RoleId = Convert.ToInt32(Session["RoleId"].ToString());
                }
            }                
        }
      
        /// <summary>
        ///  CheckRoleId is a function which is used for Edit functionality
        /// </summary>
        protected void CheckRoleId()
        {
            RoleId = Convert.ToInt32(Session["RoleId"].ToString());
            DataTable DtSelectId = GetRoleDetails(RoleId);
            if (btnSave.Text == "Save")
            {
                if (DtSelectId.Rows.Count > 0)
                {
                    txtRoleName.Text = DtSelectId.Rows[0][1].ToString();
                    txtRoleDesc.Text = DtSelectId.Rows[0][2].ToString();
                    string Status = DtSelectId.Rows[0][3].ToString();
                    if (Status == "True")
                    {
                        ddlRoleStatus.SelectedIndex = 2;
                    }
                    else
                    {
                        ddlRoleStatus.SelectedIndex = 1;
                    }
                    btnSave.Text = "Update";
                }
            }
        }

        /// <summary>
        ///  To get details of particular Role ID
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        private DataTable GetRoleDetails(int RoleId)
        {
            RoleBAL RoleBAL = new RoleBAL();
            DataTable DtRoleDe = new DataTable();
            try
            {
                DtRoleDe = RoleBAL.SelectRoleID(RoleId, LoginUser, Ret);
            }
            catch
            {
                throw;
            }
            finally
            {
                RoleBAL = null;
            }
            return DtRoleDe;
        }

        /// <summary>
        /// To save and update Role details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Status = ddlRoleStatus.SelectedItem.Text;
            bool RoleStatus;
            if (Status == "Active")
                {
                    RoleStatus = true;
                }
                else
                {
                    RoleStatus = false;
                }
                if (btnSave.Text == "Save")
                {              
                    int IntResult = 0;
                    RoleBAL RoleBAL = new RoleBAL();                   
                    string RoleName = txtRoleName.Text;
                    string RoleDesc = txtRoleDesc.Text;
                    try
                    {
                        // 'InsertRole' is Role business Access Layer function called
                        // to insert Role details
                        IntResult = RoleBAL.InsertRole(RoleName, RoleDesc, RoleStatus, LoginUser, Ret);
                        ClearRole();
                        msgRole.Msg = "Role details submited successfully";
                        msgRole.showmsg();
                    }
                    catch (Exception ee)
                    {
                        // Duplicate Entry is catched when inserting Role
                        if (ee.Message == "Duplicate Entry")
                        {
                            msgRole.Msg = "Role already exists";
                            msgRole.showmsg();
                        }
                    }
                    finally
                    {
                        RoleBAL = null;
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    int IntResult = 0;
                    RoleBAL RoleBAL = new RoleBAL();                  
                    string RoleName = txtRoleName.Text;
                    string RoleDesc = txtRoleDesc.Text;
                    try
                    {
                        // 'UpdateRole' is Role business Access Layer function called
                        // to update Role details
                        IntResult = RoleBAL.UpdateRole(RoleId, RoleName, RoleDesc, RoleStatus, LoginUser, Ret);
                        ClearRole();
                        Session["RoleId"] = null;
                        btnSave.Text = "Save";
                        Response.Redirect("RoleList.aspx", false);
                        //msgRole.Msg = "Role updated succesfully";
                        //msgRole.showmsg();
                    }
                    catch (Exception ee)
                    {
                        // Duplicate Entry is catched when updating Role
                        if (ee.Message == "Duplicate Entry")
                        {
                            msgRole.Msg = "Role already exists";
                            msgRole.showmsg();
                        }
                    }                        
                    finally
                    {
                        RoleBAL = null;
                    }
                }
             }

        /// <summary>
        /// To Clear data
        /// </summary>
        private void ClearRole()
        {
            txtRoleName.Text = "";
            txtRoleDesc.Text = "";
            ddlRoleStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// To cancel current operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearRole();
            Response.Redirect("RoleList.aspx", false);
        }
}
