
using System;
using System.Data.sqlClient;
using System.Web;
using System.Web.UI.WebControls;

protected void login(object sender, EventArgs e){
SqlConnection con = new SqlConnection(@"Data Source="";Initial Catalog=AspApplication;passward="");
{
con.open();
SqlConnection cmd = new SqlConnection("insert into tblregister values(@email,@passward)",con);
cmd.parameters.AddWithValue("email",TextBox1.Text);
cmd.parameters.AddWithValue("passward",TextBox2.Text);

cmd.ExecuteNonQuery();

TextBox1.text = "";
TextBox2.text = "";

RadioButtonList1.SelectedValue = "";
TextBox1.Focus();

}
}