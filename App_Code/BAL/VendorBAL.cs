using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for VendorBAL
/// </summary>
public class VendorBAL
{
	public VendorBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Vendor' data in VendorDAL Data Access Layer for insertion
    public int InsertVendor(int UserID, bool IsActive, int LoginUser, string Ret)
    {

        VendorDAL VendorDAL = new VendorDAL();
        try
        {
            return VendorDAL.InsertVendor(UserID, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            VendorDAL = null;
        }
    }

    //  To pass 'Vendor' data in VendorDAL Data Access Layer for updation
    public int UpdateVendor(int VendorId, bool IsActive, int LoginUser, string Ret)
    {
        VendorDAL VendorDAL = new VendorDAL();
        try
        {
            return VendorDAL.UpdateVendor(VendorId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            VendorDAL = null;
        }
    }

    // To pass 'Vendor' data in VendorDAL Data Access Layer to show Active type records
    public DataTable LoadActiveVendor(int LoggedInUser, string Ret, bool IsActive)
    {
        VendorDAL VendorDAL = new VendorDAL();
        try
        {
            return VendorDAL.LoadActiveVendor(LoggedInUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            VendorDAL = null;
        }
    }

    // To pass 'Vendor' data in VendorDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadAllVendor(int LoggedInUser, string Ret)
    {
        VendorDAL VendorDAL = new VendorDAL();
        try
        {
            return VendorDAL.LoadAllVendor(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            VendorDAL = null;
        }
    }

    // To pass 'Vendor' data in VendorDAL Data Access Layer to show selected VendorID records
    public DataTable SelectVendorID(int VendorId, int LoggedInUser, string Ret)
    {
        VendorDAL VendorDAL = new VendorDAL();
        try
        {
            return VendorDAL.SelectVendorID(VendorId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            VendorDAL = null;
        }
    }
}