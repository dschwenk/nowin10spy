using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;

namespace FixMy10
{
    class restorePoint
    {


        /*
         * 
         */
        public void CreateRestorePoint(string description)
        {
            ManagementScope oScope = new ManagementScope("\\\\localhost\\root\\default");
            ManagementPath oPath = new ManagementPath("SystemRestore");
            ObjectGetOptions oGetOp = new ObjectGetOptions();
            ManagementClass oProcess = new ManagementClass(oScope, oPath, oGetOp);

            ManagementBaseObject oInParams = oProcess.GetMethodParameters("CreateRestorePoint");
            oInParams["Description"] = description;
            oInParams["RestorePointType"] = 12; // MODIFY_SETTINGS
            oInParams["EventType"] = 100;

            ManagementBaseObject oOutParams = oProcess.InvokeMethod("CreateRestorePoint", oInParams, null);
        }


    }
}
