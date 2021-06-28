using BankLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillCmbCustomers();
        }

        //Tilføjer kunderne til combobox
        private void FillCmbCustomers()
        {
            List<Customer> customers = Bank.ReturnCustomers();
            foreach (var c in customers)
            {
                cmbCustomers.Items.Add(c.ToString());
            }
        }
        //Indsætter information om kunden i et label, når der vælges en kunde i combobox
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer c = Bank.GetCustomer(cmbCustomers.SelectedItem.ToString());
            lblContent.Content = "Navn: " + c.Name + "\nAdresse: " + c.Address;
            FillCmbAccounts(c);
        }
        //Fylder combobox med konti tilknyttet en kude
        private void FillCmbAccounts(Customer c)
        {
            cmbAccounts.Items.Clear();
            List<Account> accounts = Bank.GetCustomerAccounts(c);
            foreach (var a in accounts)
            {
                cmbAccounts.Items.Add(a.AccountNumber);
            }
        }
        //Sætter labels med information om den valgte konto
        private void cmbAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbAccounts.SelectedItem != null)
            {
                Account a = Bank.GetAccount(cmbAccounts.SelectedItem.ToString());
                lblBalance.Content = "SALDO: " + a.Balance;
                lblOptions.Content = "Konto - " + a.AccountNumber;
            }

        }
        //Indsætter / hæver penge fra kundens konto, opdaterer label med ny saldo
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Account a = Bank.GetAccount(cmbAccounts.SelectedItem.ToString());
            decimal amount;
            //Replace . med komma, da . giver et forkert beløb.
            bool succes = decimal.TryParse(txtAmount.Text.Replace(".", ","), out amount);
            if(succes)
            {
                //Hardcoded til index, havde nogle problemer med cmbOptions.SelctedItem.ToString() == "Indsæt"
                if(cmbOptions.SelectedIndex == 0)
                {
                    a.Deposit(amount);
                    lblBalance.Content = "SALDO: " + a.Balance;
                }
                else if (cmbOptions.SelectedIndex == 1)
                {
                    a.Withdraw(amount);
                    lblBalance.Content = "SALDO: " + a.Balance;
                }
            }
            txtAmount.Text = "";
            ShowTranscations(a);
        }

        private void ShowTranscations(Account a)
        {
            //lbTrans.Items.Clear();
            
        }
    }
}
