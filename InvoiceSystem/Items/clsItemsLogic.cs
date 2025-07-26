using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Items
{
    public class clsItemsLogic
    {
        //Database Class Instance
        //Item SQL Access
        public void exeItemSQL() 
        {
            try 
            { 
                //Executes Item logic
            }
            catch (Exception ex) 
            {
                //Throws Exception
                throw new Exception(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
