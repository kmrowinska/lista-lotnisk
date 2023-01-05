using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lista_lotnisk
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Form f2 = System.Windows.Forms.Application.OpenForms["Form2"];
        public DataTable table = new DataTable("table");
        public List<Class1> list = new List<Class1>();
        Class1 dane = new Class1();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /*load from file*/
        private void button2_Click(object sender, EventArgs e)
        {
            
            string[] text = System.IO.File.ReadAllLines("C:\\Users\\kinga\\Desktop\\dane1.csv");
            string[] data_col = null;
            int x = 0;

            foreach (string line in text)
            {
                data_col = line.Split(',');
                if (x == 0)
                {
                    /*for (int i = 0; i < data_col.Count(); i++)
                    {
                        table.Columns.Add(data_col[i]);
                    }*/
                    x++;
                    list.Add(new Class1 { Miasto = data_col[0], Wojewodztwo = data_col[1], ICAO = data_col[2], IATA = data_col[3], Nazwa = data_col[4], Liczba_pasazerow = data_col[5], Zmiana = data_col[6] });

                }
                else
                {
                    /*table.Rows.Add(data_col);*/
                    list.Add(new Class1 { Miasto = data_col[0], Wojewodztwo = data_col[1], ICAO = data_col[2], IATA = data_col[3], Nazwa = data_col[4], Liczba_pasazerow = data_col[5], Zmiana = data_col[6] });
                }
            }
            dataGridView1.DataSource= list;
            dataGridView1.Columns["Miasto"].Visible= false;
            dataGridView1.Columns["Wojewodztwo"].Visible = false;
            dataGridView1.Columns["ICAO"].Visible = false;
            dataGridView1.Columns["IATA"].Visible = false;
            dataGridView1.Columns["Liczba_pasazerow"].Visible = false;
            dataGridView1.Columns["Zmiana"].Visible = false;

        }

        /*details
         zrobic switch case */
        private void button1_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.Show();
            ((Form2)f2).listBox1.Items.Clear();
            int row_index = dataGridView1.CurrentCell.RowIndex;
            int col_index = dataGridView1.CurrentCell.ColumnIndex;
            string sel_name = dataGridView1.Rows[row_index].Cells[col_index].Value.ToString();

            Class1 sel_airport = null;
            foreach(Class1 airport in list)
            {
                if(airport.Nazwa == sel_name)
                {
                    sel_airport = airport;
                    break;
                }
            }

            foreach(string sel_item in checkedListBox1.CheckedItems)
            {
                if (sel_item == "Kod lotniska ICAO")
                {
                    ((Form2)f2).listBox1.Items.Add(sel_item + ":");
                    ((Form2)f2).listBox1.Items.Add(sel_airport.ICAO);
                }
                else if (sel_item == "Kod lotniska IATA")
                {
                    ((Form2)f2).listBox1.Items.Add(sel_item + ":");
                    ((Form2)f2).listBox1.Items.Add(sel_airport.IATA);
                    
                }
                else if (sel_item == "Liczba pasażerów")
                {
                    ((Form2)f2).listBox1.Items.Add(sel_item + ":");
                    ((Form2)f2).listBox1.Items.Add(sel_airport.Liczba_pasazerow);
                    
                }
                else if (sel_item == "Województwo")
                {
                    ((Form2)f2).listBox1.Items.Add(sel_item + ":");
                    ((Form2)f2).listBox1.Items.Add(sel_airport.Wojewodztwo);
                    
                }
                else if (sel_item == "Miasto")
                {
                    ((Form2)f2).listBox1.Items.Add(sel_item + ":");
                    ((Form2)f2).listBox1.Items.Add(sel_airport.Miasto);
                    
                }
            }

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
