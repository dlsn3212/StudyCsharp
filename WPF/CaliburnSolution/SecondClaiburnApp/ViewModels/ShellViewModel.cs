using Caliburn.Micro;
using MySql.Data.MySqlClient;
using SecondClaiburnApp.Helpers;
using SecondClaiburnApp.Models;
using SecondClaiburnApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCaliburnApp.ViewModels
{
    class ShellViewModel : Conductor<object>, IHaveDisplayName
    {
        public override string DisplayName { get; set; }

        string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
                

            }
        }

        public string FullName
        {
            //get => string.Format("{0} {1}", FirstName, LastName);
            get => $"{FirstName} {LastName}";
        }
        public ShellViewModel()
        {
            DisplayName = "Second Caliburn App";

            People = new BindableCollection<PersonModel>();
            InitCombobox();


            //FirstName = "Yujin";
            //People.Add(new PersonModel { LastName = "Gates", FirstName = "Bill" });
            //People.Add(new PersonModel { LastName = "Jobs", FirstName = "Steve" });
            //People.Add(new PersonModel { LastName = "Musk", FirstName = "Ellen" });
        }

        private void InitCombobox()
        {   // nuget에 mysql 깔아야 실행 가능
            People.Add(new PersonModel { LastName = " ", FirstName = "--선택--" });
            using (MySqlConnection conn = new MySqlConnection(Commons.STRCONNSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.SELECTPEOPLEQUERY, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var temp = new PersonModel
                    {
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };
                    People.Add(temp);
                }
            }
            SelectedPerson = People.Where(v => v.FirstName.Contains("선택")).First();
        }

        // 콤보 박스 사람 리스트
        public BindableCollection<PersonModel> People { get; set; }               //viewmodel이 받아서 view로 감

        PersonModel selectedPerson;

        public PersonModel SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                this.LastName = selectedPerson.LastName;                                                            //viewmodel에 있는 lastname
                this.FirstName = selectedPerson.FirstName;
                NotifyOfPropertyChange(() => SelectedPerson);                                                   //model이랑 viewmodel이랑 연동 빠져선 안된다.
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        public void ClearName()
        {
            this.FirstName = this.LastName = string.Empty;
        }
        public bool CanClearName
        {
            get => !(string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName));

        }

        public void LoadPageOne()
        {   //UserControl FirstChildView
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {   //UserControl SecondChildView
            ActivateItem(new SecondChildViewModel());
        }

    }
}
