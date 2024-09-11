using PAW.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    namespace PAW
    {
        public partial class AddEditForm : Form
        {
            private const string ConnectionString = "Data Source=PizzaDatabase.db";

            private Client clients;
            public Client NewClient { get; set; }
            public Address NewAddress { get; set; }
            public Pizza NewPizza { get; set; }
            public AddEditForm(Client client)
            {
                clients = client;
                InitializeComponent();
                StartPosition = FormStartPosition.CenterScreen;
            }

            private void btnOk_Click(object sender, EventArgs e)
            {
                clients.ClientId = (int)numClientId.Value;
                clients.LastName = lastName.Text;
                clients.FirstName = firstName.Text;
                clients.PhoneNo = phoneNo.Text;

                clients.AddressId = (int)numAddressId.Value;

            if (clients.ClientAddress == null)
                clients.ClientAddress = new Address();

                clients.ClientAddress.AddressId = (int)numAddressId.Value;
                clients.ClientAddress.Street = street.Text;
                clients.ClientAddress.Floor = floor.Text;
                clients.ClientAddress.Apartment = apartment.Text;

                clients.ClientAddress.ClientId = (int)numClientId.Value;


            if (clients.ClientPizza == null)
                clients.ClientPizza = new Pizza();

                clients.ClientPizza.PizzaId = (int)numPizzaId.Value;
                clients.ClientPizza.PizzaType = pizzaType.Text;
                clients.ClientPizza.PizzaSize = pizzaSize.Text;

                clients.ClientPizza.ClientId = (int)numClientId.Value;

            NewClient = new Client(clients.ClientId, clients.AddressId, clients.LastName, clients.FirstName, clients.PhoneNo);
            NewAddress = new Address(clients.ClientAddress.AddressId, clients.ClientAddress.ClientId, clients.ClientAddress.Street, clients.ClientAddress.Floor, clients.ClientAddress.Apartment);
            NewPizza = new Pizza(clients.ClientPizza.PizzaId, clients.ClientPizza.ClientId, clients.ClientPizza.PizzaType, clients.ClientPizza.PizzaSize);
            try
            {
                AddClient(clients);
                AddAddress(clients.ClientAddress);
                AddPizza(clients.ClientPizza);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            private void EditForm_Load(object sender, EventArgs e)
            {
            numClientId.Select();
            this.KeyPreview = true;
                numClientId.Value = clients.ClientId; 
                lastName.Text = clients.LastName;
                firstName.Text = clients.FirstName;
                phoneNo.Text = clients.PhoneNo;

            if (clients.ClientAddress != null)
            {
                numAddressId.Value = clients.ClientAddress.AddressId;
                street.Text = clients.ClientAddress.Street;
                floor.Text = clients.ClientAddress.Floor;
                apartment.Text = clients.ClientAddress.Apartment;
            }
            if (clients.ClientPizza != null)
            {
                numPizzaId.Value = clients.ClientPizza.PizzaId;
                pizzaType.Text = clients.ClientPizza.PizzaType;
                pizzaSize.Text = clients.ClientPizza.PizzaSize;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            numClientId.Value = 0;
            lastName.Text = "";
            firstName.Text = "";
            phoneNo.Text = "";

            if (clients.ClientAddress != null)
            {
                numAddressId.Value = 0;
                street.Text = "";
                floor.Text = "";
                apartment.Text = "";
            }
            if (clients.ClientPizza != null)
            {
                numPizzaId.Value = 0;
                pizzaType.Text = "";
                pizzaSize.Text = "";
            }
        }

        #region AddInfo
        private void AddClient(Client client)
        {
            var queryCount = "SELECT COUNT(*) FROM Client WHERE ClientId = @ClientId";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using(SQLiteCommand checkCommand = new SQLiteCommand(queryCount, connection))
                {
                    checkCommand.Parameters.AddWithValue("@ClientId", NewClient.ClientId);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        var queryUpdate = "UPDATE Client SET LastName = @LastName, FirstName = @FirstName, PhoneNo = @PhoneNo WHERE ClientId = @ClientId";
                        using (SQLiteCommand updateCommand = new SQLiteCommand(queryUpdate, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@ClientId", NewClient.ClientId);
                            updateCommand.Parameters.AddWithValue("@LastName", NewClient.LastName);
                            updateCommand.Parameters.AddWithValue("@FirstName", NewClient.FirstName);
                            updateCommand.Parameters.AddWithValue("@PhoneNo", NewClient.PhoneNo);

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        var queryInsert = "INSERT INTO Client(ClientId, AddressId, LastName, FirstName, PhoneNo)" + " VALUES (@ClientId, @AddressId, @LastName, @FirstName, @PhoneNo); " + "SELECT last_insert_rowid()";
                        using (SQLiteCommand insertCommand = new SQLiteCommand(queryInsert, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@ClientId", NewClient.ClientId);
                            insertCommand.Parameters.AddWithValue("@AddressId", NewClient.AddressId);
                            insertCommand.Parameters.AddWithValue("@LastName", NewClient.LastName);
                            insertCommand.Parameters.AddWithValue("@FirstName", NewClient.FirstName);
                            insertCommand.Parameters.AddWithValue("@PhoneNo", NewClient.PhoneNo);

                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void AddAddress(Address address)
        {
            var queryCount = "SELECT COUNT(*) FROM Address WHERE ClientId = @ClientId";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand checkCommand = new SQLiteCommand(queryCount, connection))
                {
                    checkCommand.Parameters.AddWithValue("@ClientId", NewAddress.ClientId);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        var queryUpdate = "UPDATE Address SET Street = @Street, Floor = @Floor, Apartment = @Apartment WHERE ClientId = @ClientId";
                        using (SQLiteCommand updateCommand = new SQLiteCommand(queryUpdate, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@ClientId", NewAddress.Street);
                            updateCommand.Parameters.AddWithValue("@Street", NewAddress.Street);
                            updateCommand.Parameters.AddWithValue("@Floor", NewAddress.Floor);
                            updateCommand.Parameters.AddWithValue("@Apartment", NewAddress.Apartment);

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        var queryInsert = "INSERT INTO Address(AddressId, ClientId, Street, Floor, Apartment)" + " VALUES (@AddressId, @ClientId, @Street, @Floor, @Apartment); " + "SELECT last_insert_rowid()";
                        using (SQLiteCommand insertCommand = new SQLiteCommand(queryInsert, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@AddressId", NewAddress.AddressId);
                            insertCommand.Parameters.AddWithValue("@ClientId", NewAddress.ClientId);
                            insertCommand.Parameters.AddWithValue("@Street", NewAddress.Street);
                            insertCommand.Parameters.AddWithValue("@Floor", NewAddress.Floor);
                            insertCommand.Parameters.AddWithValue("@Apartment", NewAddress.Apartment);

                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void AddPizza(Pizza pizza)
        {
            var queryCount = "SELECT COUNT(*) FROM Pizza WHERE ClientId = @ClientId";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand checkCommand = new SQLiteCommand(queryCount, connection))
                {
                    checkCommand.Parameters.AddWithValue("@ClientId", NewPizza.ClientId);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        var queryUpdate = "UPDATE Pizza SET PizzaType = @PizzaType, PizzaSize = @PizzaSize WHERE ClientId = @ClientId";
                        using (SQLiteCommand updateCommand = new SQLiteCommand(queryUpdate, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@ClientId", NewPizza.ClientId);
                            updateCommand.Parameters.AddWithValue("@PizzaType", NewPizza.PizzaType);
                            updateCommand.Parameters.AddWithValue("@PizzaSize", NewPizza.PizzaSize);

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        var queryInsert = "INSERT INTO Pizza(PizzaId, ClientId, PizzaType, PizzaSize)" + " VALUES (@PizzaId, @ClientId, @PizzaType, @PizzaSize); " + "SELECT last_insert_rowid()";
                        using (SQLiteCommand insertCommand = new SQLiteCommand(queryInsert, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@PizzaId", NewPizza.PizzaId);
                            insertCommand.Parameters.AddWithValue("@ClientId", NewPizza.ClientId);
                            insertCommand.Parameters.AddWithValue("@PizzaType", NewPizza.PizzaType);
                            insertCommand.Parameters.AddWithValue("@PizzaSize", NewPizza.PizzaSize);

                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        #endregion

        #region Validations
        private void lastName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(lastName, null);
        }

        private void lastName_Validating(object sender, CancelEventArgs e)
        {
            if (lastName.Text.Length < 3)
            {
                errorProvider.SetError(lastName, "Name: min 3 letters");
                e.Cancel = true;
            }
        }
        private void firstName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(firstName, null);
        }

        private void firstName_Validating(object sender, CancelEventArgs e)
        {
            if (firstName.Text.Length < 3)
            {
                errorProvider.SetError(firstName, "Name: min 3 letters");
                e.Cancel = true;
            }
        }
        private void phoneNo_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(phoneNo, null);
        }

        private void phoneNo_Validating(object sender, CancelEventArgs e)
        {
            if (phoneNo.Text.Length != 10)
            {
                errorProvider.SetError(phoneNo, "Check number");
                e.Cancel = true;
            }
        }

        private void numClientId_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(numClientId, null);
        }

        private void numClientId_Validating(object sender, CancelEventArgs e)
        {
            if (numClientId.Value < 1)
            {
                errorProvider.SetError(numClientId, "Invalid ID");
                e.Cancel = true;
            }
        }
        private void numAddressId_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(numAddressId, null);
        }

        private void numAddressId_Validating(object sender, CancelEventArgs e)
        {
            if (numAddressId.Value < 1)
            {
                errorProvider.SetError(numAddressId, "Invalid ID");
                e.Cancel = true;
            }
        }

        private void numPizzaId_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(numPizzaId, null);
        }

        private void numPizzaId_Validating(object sender, CancelEventArgs e)
        {
            if (numPizzaId.Value < 1)
            {
                errorProvider.SetError(numPizzaId, "Invalid ID");
                e.Cancel = true;
            }
        }
        #endregion

        #region KeyPress
        private void phoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void lastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Alt Shortcuts
        private void AddEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt == true && e.KeyCode == Keys.S)
            {
                btnOk.PerformClick();
            }
            if (e.Alt == true && e.KeyCode == Keys.E)
            {
                btnClear.PerformClick();
            }
            if (e.Alt == true && e.KeyCode == Keys.C)
            {
                btnCancel.PerformClick();
            }
        }
        #endregion

    }
}
