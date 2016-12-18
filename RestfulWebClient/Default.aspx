<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <script type="text/javascript" src="Scripts/jquery-2.1.0.min.js">

    </script>
    <script type="text/javascript">
        function AddNewEmployee() {

            var emp = {
                "FirstName": "dad",
                "LastName": "hyju",
                "EmpCode": 3554,
                "Designation": "dsas"
            };

            $.ajax({
                type: "POST",
                url: "http://localhost:8038/EmployeeService.svc/AddEmployee",
                data: JSON.stringify(emp),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                crossDomain: true,
                success: function (data, status, xmlRequest) {
                    alert("JSON içeriği " + JSON.stringify(emp) + ". " + data + " numaralı ürün eklenmiştir");
                    // xmlRequest = XMLHttpRequest 
                },
                error: function (xmlRequest, status, errorThrown) {
                    alert(xmlRequest.responseText);
                }
            });
        };

        function UpdateEmployee() {

            var emp = {
                "FirstName": "dadUpdate",
                "LastName": "hyjuUpdate",
                "EmpCode": 3554,
                "Designation": "dsas"
            };

            $.ajax({
                type: "PUT",
                url: "http://localhost:8038/EmployeeService.svc/UpdateEmployee",
                data: JSON.stringify(emp),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                crossDomain: true,
                success: function (data, status, xmlRequest) {
                    alert("JSON içeriği " + JSON.stringify(emp) + ". " + data + " numaralı ürün güncellenmiştir");
                    // xmlRequest = XMLHttpRequest 
                },
                error: function (xmlRequest, status, errorThrown) {
                    alert(xmlRequest.responseText);
                }
            });
        };
        function DeleteEmployee() {

            var empcode = "3554";
             
            $.ajax({
                type: "DELETE",
                url: "http://localhost:8038/EmployeeService.svc/DeleteEmployee/" + empcode,
                data: JSON.stringify(empcode),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                crossDomain: true,
                success: function (data, status, xmlRequest) {
                    alert("JSON içeriği " + JSON.stringify(empcode) + ". " + data + " numaralı ürün silinmiştir");
                    // xmlRequest = XMLHttpRequest 
                },
                error: function (xmlRequest, status, errorThrown) {
                    alert(xmlRequest.responseText);
                }
            });
        }
    </script>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td><asp:Button ID="ButtonGetAnEmployee" runat="server" Text="Get An Employee" OnClick="ButtonGetAnEmployee_Click" /></td>
            </tr>
            <tr>
                <td>
                     <input type="button" value="Add New Employee" onclick="AddNewEmployee()" />
                </td>
            </tr>
            <tr>
                <td>
                     <input type="button" value="Update Employee" onclick="UpdateEmployee()" />
                </td>
            </tr>
            <tr>
                <td>
                     <input type="button" value="Delete Employee" onclick="DeleteEmployee()" />
                </td>
            </tr>
            <tr>
                <td>
                     <asp:TextBox ID="TextBoxExp" runat="server" Height="117px" TextMode="MultiLine" Width="293px" /> 
                </td>
            </tr>
        </table>
    
    </div>
        

        
    </form>
</body>
</html>
