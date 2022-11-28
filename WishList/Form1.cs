using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WishList
{
    public partial class Form1 : Form
    {
        ListView listView1;
        Button buttonAdd;
        TextBox NameNewItem;
        TextBox PriceNewItem;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
          
            listView1 = new ListView();
            buttonAdd = new Button();
            NameNewItem = new TextBox();
            PriceNewItem = new TextBox();

            // Зададим размер и местоположение списка на форме
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(315, 300));

            NameNewItem.Bounds = new Rectangle(new Point(120, 325), new Size(100, 30));
            NameNewItem.Text = "Введите название";
            NameNewItem.Parent = this;

            PriceNewItem.Bounds = new Rectangle(new Point(225, 325), new Size(90, 30));
            PriceNewItem.Text = "Введите цену";
            PriceNewItem.Parent = this;

            buttonAdd.Bounds = new Rectangle(new Point(10, 320), new Size(80, 30));
            buttonAdd.Parent = this;
            buttonAdd.Text = "Добавить";
            buttonAdd.Click += buttonAdd_Click;
            // Установим табличный режим отображения
            listView1.View = View.Details;

            // Позволим пользователю редактировать поле элемента списка
            listView1.LabelEdit = true;

            // Позволим пользователю перемещать столбцы в табличном режиме
            listView1.AllowColumnReorder = true;

            // Возле каждого элемента списка будет флажок
            listView1.CheckBoxes = true;

            // При выборе элемента списка будет подсвечена вся строка
            listView1.FullRowSelect = true;

            // Отобразим линии сетки в табличном режиме
            listView1.GridLines = true;

            // Создадим три элемента списка и три подэлемента для каждого из них 
            ListViewItem item1 = new ListViewItem("Велосипед", 0);
            item1.SubItems.Add("4000");

            ListViewItem item2 = new ListViewItem("Наушники", 1);
            item2.Checked = true; // Флажок элемента списка будет включен
            item2.SubItems.Add("3500");
        
            ListViewItem item3 = new ListViewItem("Гитара", 0);
            item3.SubItems.Add("4650");

            ListViewItem item4 = new ListViewItem("Телефон", 1);
            item4.SubItems.Add("7500");

            ListViewItem item5 = new ListViewItem("АВТОМОБИЛЬ",random.Next(0,2));
            item5.SubItems.Add("5000000");

            // Создадим колонки (1 параметр - название столбца, 2 параметр - ширина столбца, выравнивание названия)
            listView1.Columns.Add("Название", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Цена - ГРН", 115, HorizontalAlignment.Left);

            // Добавляем элементы в список
            listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3, item4, item5 });

            // Создаем два пустых списка изображений для больших и малых значков
            ImageList imageListSmall = new ImageList();
            ImageList imageListLarge = new ImageList();

            // Инициализируем списки изображений картинками
            imageListSmall.Images.Add(Bitmap.FromFile("1.bmp"));
            imageListSmall.Images.Add(Bitmap.FromFile("2.bmp"));
            imageListLarge.Images.Add(Bitmap.FromFile("3.bmp"));
            imageListLarge.Images.Add(Bitmap.FromFile("4.bmp"));

            // ассоциируем списки изображений с ListView
            listView1.LargeImageList = imageListLarge;
            listView1.SmallImageList = imageListSmall;

            // Добавляем ListView в коллекцию элементов управления
            this.Controls.Add(listView1);

            Width = 350; // Ширина формы
            Height = 400; // Высота формы
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            if (NameNewItem.Text.Length != 0 && PriceNewItem.Text.Length != 0 && NameNewItem.Text != "Введите название" && PriceNewItem.Text != "Введите цену")
            {
                ListViewItem Newitem = new ListViewItem(NameNewItem.Text, random.Next(0,2));
                Newitem.SubItems.Add(PriceNewItem.Text);
                listView1.Items.Add(Newitem);
            }
            else
            {
                MessageBox.Show("Одно из полей не заполненно!");
            }
            NameNewItem.Text = "Введите название";
            PriceNewItem.Text = "Введите цену";
        }
    }
}
