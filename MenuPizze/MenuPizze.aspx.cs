using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuPizze
{
    public partial class MenuPizze : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RiepilogoConto.Visible= false;

            if (!IsPostBack)
            {
                foreach(Menu item in Menu.GetMenu())
                {
                
                    ListItem l = new ListItem(item.NomePiatto, item.Id.ToString());
                    ElencoPizze.Items.Add(l);
                }

            }
        }

        protected void AggiungiPizza_Click(object sender, EventArgs e)
        {
            int piattoScelto = Convert.ToInt32(ElencoPizze.SelectedValue);

            foreach(Menu item in Menu.GetMenu())
            {
                if (item.Id == piattoScelto)
                {
                    string aggiunta = "";
                    decimal CostoAggiunta = 0;

                    foreach(ListItem agg in CheckBoxListExtra.Items)
                    {
                        if (agg.Selected)
                        {
                            aggiunta += $"+{agg.Text}";
                            CostoAggiunta += Convert.ToInt32(agg.Value);
                        }
                    }

                    Menu piatto = new Menu()
                    {
                        NomePiatto = $"{item.NomePiatto} {aggiunta};",
                        CostoPiatto = item.CostoPiatto + CostoAggiunta
                    };
                    Menu.ListaMenuOrdinato.Add(piatto);
                }
            }
            
        }

        protected void ConcludiOrdine_Click(object sender, EventArgs e)
        {
            decimal totale = 0;
            foreach (Menu m in Menu.ListaMenuOrdinato)
            {
                ElencoOrdine.Text += $"{m.NomePiatto} : <b>{m.CostoPiatto.ToString("c2")} </b></br>";
                totale += m.CostoPiatto;
            }
            TotaleConto.Text = $"Totale da pagare {totale.ToString("c2")}";
            RiepilogoConto.Visible = true;
        }
    }

    public class Menu
    {
        public int Id { get; set; }
        public string NomePiatto { get; set; }
        public decimal CostoPiatto { get; set; }
        public static List<Menu> ListaMenuOrdinato = new List<Menu>();
        public static List<Menu> GetMenu()
        {
            List<Menu> list = new List<Menu>();

            Menu piatto1 = new Menu { Id = 1, NomePiatto = "Margherita", CostoPiatto = 10.00m };
            Menu piatto2 = new Menu { Id = 2, NomePiatto = "Americana", CostoPiatto = 12.00m };
            Menu piatto3 = new Menu { Id = 3, NomePiatto = "Capricciosa", CostoPiatto = 14.00m };
            Menu piatto4 = new Menu { Id = 4, NomePiatto = "Diavola", CostoPiatto = 15.00m };
            Menu piatto5 = new Menu { Id = 5, NomePiatto = "Pizza Fritta", CostoPiatto = 8.00m };

            list.Add(piatto1);
            list.Add(piatto2);  
            list.Add(piatto3);
            list.Add(piatto4);
            list.Add(piatto5);

            return list;
        }
    }
}