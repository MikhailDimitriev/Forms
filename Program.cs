using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Web;

namespace Forms
{
    class Program
    {
        static void Main(string[] args)
        {
            Form mainForm = new myForm("Форма");
            Application.Run(mainForm);
        }

        public class myForm : Form
        {
            private bool _mouseOnForm = false;
            public myForm(string title)
            {
                Text = title;
                Height = 600;
                Width = 1000;
                StartPosition = FormStartPosition.CenterScreen;

                Button exitButton = CreateButton(new Size(150, 50), new Point(810, 25), "Выход из формы.");
                exitButton.Click += (sender, e) => Application.Exit();
                Label greetings = CreateLabel(new Size(300, 50), new Point(385, 200), "Приветствую вас в моей форме.");
                Label click = CreateLabel(new Size(300, 50), new Point(350, 250), "Щелкните 2 раза чтобы увидеть автора формы.");
                Label author = CreateLabel(new Size(400, 50), new Point(335, 200), "Автор формы: студент группы 3231302/20801 Димитриев М.Д.");
                greetings.Visible = true;
                click.Visible = true;
                author.Visible = false;
                DoubleClick += (sender, e) =>
                {
                    ShowLabel(author);
                    HideLable(greetings, click);
                };
                MouseEnter += (sender, e) => _mouseOnForm = true;
                MouseLeave += (sender, e) => _mouseOnForm = false;
            }

            private void HideLable(Label greetings, Label click)
            {
                if (_mouseOnForm)
                {
                    greetings.Visible = false;
                    click.Visible = false;
                }
            }

            private void ShowLabel(Label author)
            {
                if (_mouseOnForm) author.Visible = true;
            }

            private void SetCommonParametres(Control element, Size size, Point position, string title) 
            {
                element.Size = size;
                element.Location = position;
                element.Text = title;
                Controls.Add(element);
            }
            private Button CreateButton(Size size, Point position, string title)
            {
                Button button = new Button();
                SetCommonParametres(button, size, position, title);
                return button;
            }
            private Label CreateLabel(Size size, Point position, string title)
            {
                Label label = new Label ();
                SetCommonParametres(label, size, position, title);
                return label;
            }
        }  
    }
}
