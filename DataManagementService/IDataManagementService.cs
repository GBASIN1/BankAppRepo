using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataManagementService.Entity;
using System.Data;

namespace DataManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataManagementService
    {

        [OperationContract]
        ResultSet GetDataFromTable(TableSchema tableSchema);

        [OperationContract]
        bool AddCustomerDetail(CustDetail customerDetail);

        [OperationContract]
        ResultSet GetCustomerDetails(out int NoOfRecords);

        [OperationContract]
        bool InsertCustomerData(CustDetail customerDetail);

        [OperationContract(Name="GetCustomerList")]
        ResultSet GetCustomerDetails();
    }


}
