using System;
using System.Data.sqlClient;
using System.Web;
using System.Web.UI.WebControls;

protected void Register(object sender, EventArgs e){
SqlConnection con = new SqlConnection(@"Data Source="";Initial Catalog=AspApplication;passward="");
{
con.open();
SqlConnection cmd = new SqlConnection("insert into tblregister values(@fname,@lname,@email,@passward,@creditId,@phoneNum,@address,@usertype)",con);
cmd.parameters.AddWithValue("fname",TextBox1.Text);
cmd.parameters.AddWithValue("lname",TextBox2.Text);
cmd.parameters.AddWithValue("email",TextBox3.Text);
cmd.parameters.AddWithValue("passward",TextBox4.Text);
cmd.parameters.AddWithValue("creditId",TextBox5.Text);
cmd.parameters.AddWithValue("phoneNum",TextBox6.Text);
cmd.parameters.AddWithValue("address",TextBox7.Text);
cmd.parameters.AddWithValue("usertype",RadioButtonList1.SelectedValue);
cmd.ExecuteNonQuery();

TextBox1.text = "";
TextBox2.text = "";
TextBox3.text = "";
TextBox4.text = "";
TextBox5.text = "";
TextBox6.text = "";
TextBox7.text = "";
RadioButtonList1.SelectedValue = "";
TextBox1.Focus();

}
}
