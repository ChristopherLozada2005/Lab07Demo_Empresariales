using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Business;
using Entity;

namespace Lab07Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // PRODUCTOS

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            var business = new BProduct();
            var products = business.Read();
            ItemsDataGrid.ItemsSource = products;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name es requerido."); return;
            }
            if (!decimal.TryParse(txtPrice.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out var price))
            {
                MessageBox.Show("Price inválido."); return;
            }
            if (!int.TryParse(txtStock.Text, out var stock))
            {
                MessageBox.Show("Stock inválido."); return;
            }

            var product = new Product
            {
                Name = txtName.Text.Trim(),
                Price = price,
                Stock = stock
            };

            try
            {
                var business = new BProduct();
                business.Create(product);
                MessageBox.Show("Product Created.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsDataGrid.SelectedItem is Product selected)
            {
                selected.Name = txtName.Text.Trim();
                if (!decimal.TryParse(txtPrice.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out var price))
                {
                    MessageBox.Show("Price inválido."); return;
                }
                if (!int.TryParse(txtStock.Text, out var stock))
                {
                    MessageBox.Show("Stock inválido."); return;
                }
                selected.Price = price;
                selected.Stock = stock;

                try
                {
                    var business = new BProduct();
                    business.Update(selected);
                    MessageBox.Show("Producto actualizado.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsDataGrid.SelectedItem is Product selected)
            {
                try
                {
                    var business = new BProduct();
                    business.Delete(selected);
                    MessageBox.Show("Producto eliminado.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void ItemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsDataGrid.SelectedItem is Product selected)
            {
                txtName.Text = selected.Name;
                txtPrice.Text = selected.Price.ToString(CultureInfo.InvariantCulture);
                txtStock.Text = selected.Stock.ToString();
            }
        }

        // CLIENTES

        private void ReadCustomer_Click(object sender, RoutedEventArgs e)
        {
            var business = new BCostumer();
            var customers = business.Read();
            CustomersDataGrid.ItemsSource = customers;
        }

        private void CreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Name es requerido."); return;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerAddress.Text))
            {
                MessageBox.Show("Address es requerido."); return;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerPhone.Text))
            {
                MessageBox.Show("Phone es requerido."); return;
            }

            var customer = new Costumer
            {
                Name = txtCustomerName.Text.Trim(),
                Address = txtCustomerAddress.Text.Trim(),
                Phone = txtCustomerPhone.Text.Trim()
            };

            try
            {
                var business = new BCostumer();
                business.Create(customer);
                MessageBox.Show("Customer Created.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersDataGrid.SelectedItem is Costumer selected)
            {
                selected.Name = txtCustomerName.Text.Trim();
                selected.Address = txtCustomerAddress.Text.Trim();
                selected.Phone = txtCustomerPhone.Text.Trim();

                try
                {
                    var business = new BCostumer();
                    business.Update(selected);
                    MessageBox.Show("Cliente actualizado.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersDataGrid.SelectedItem is Costumer selected)
            {
                try
                {
                    var business = new BCostumer();
                    business.Delete(selected);
                    MessageBox.Show("Cliente eliminado.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void CustomersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomersDataGrid.SelectedItem is Costumer selected)
            {
                txtCustomerName.Text = selected.Name;
                txtCustomerAddress.Text = selected.Address;
                txtCustomerPhone.Text = selected.Phone;
            }
        }

        // FACTURAS

        private void ReadInvoice_Click(object sender, RoutedEventArgs e)
        {
            var business = new BInvoice();
            var invoices = business.Read();
            InvoicesDataGrid.ItemsSource = invoices;
        }

        private void CreateInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtInvoiceCustomerID.Text, out var customerId))
            {
                MessageBox.Show("CustomerID inválido."); return;
            }
            if (!dpInvoiceDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Date es requerido."); return;
            }
            if (!decimal.TryParse(txtInvoiceTotal.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out var total))
            {
                MessageBox.Show("Total inválido."); return;
            }

            var invoice = new Invoice
            {
                CustomerID = customerId,
                Date = dpInvoiceDate.SelectedDate.Value,
                Total = total
            };

            try
            {
                var business = new BInvoice();
                business.Create(invoice);
                MessageBox.Show("Factura creada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void UpdateInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (InvoicesDataGrid.SelectedItem is Invoice selected)
            {
                if (!int.TryParse(txtInvoiceCustomerID.Text, out var customerId))
                {
                    MessageBox.Show("CustomerID inválido."); return;
                }
                if (!dpInvoiceDate.SelectedDate.HasValue)
                {
                    MessageBox.Show("Date es requerido."); return;
                }
                if (!decimal.TryParse(txtInvoiceTotal.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out var total))
                {
                    MessageBox.Show("Total inválido."); return;
                }

                selected.CustomerID = customerId;
                selected.Date = dpInvoiceDate.SelectedDate.Value;
                selected.Total = total;

                try
                {
                    var business = new BInvoice();
                    business.Update(selected);
                    MessageBox.Show("Factura actualizada.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void DeleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (InvoicesDataGrid.SelectedItem is Invoice selected)
            {
                try
                {
                    var business = new BInvoice();
                    business.Delete(selected);
                    MessageBox.Show("Factura eliminada.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void InvoicesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InvoicesDataGrid.SelectedItem is Invoice selected)
            {
                txtInvoiceCustomerID.Text = selected.CustomerID.ToString();
                dpInvoiceDate.SelectedDate = selected.Date;
                txtInvoiceTotal.Text = selected.Total.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}