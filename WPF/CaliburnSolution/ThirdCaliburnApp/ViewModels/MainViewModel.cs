using Caliburn.Micro;
using MvvmDialogs;
using MySql.Data.MySqlClient;
using System.Windows;
using ThirdCaliburnApp.Models;
using static ThirdCaliburnApp.Commons;

namespace ThirdCaliburnApp.ViewModels
{
    public class MainViewModel : Conductor<object>, IHaveDisplayName
    {

        #region 속성영역

        readonly IWindowManager windowManager;
        readonly IDialogService dialogService;

        int id;
        string empName;
        decimal salary;
        string deptName;
        string destination;

        #endregion

        #region 생성자영역

        public MainViewModel(IWindowManager windowManager, IDialogService dialogService)
        {
            this.windowManager = windowManager;
            this.dialogService = dialogService;
            GetEmployees();
        }

        public int Id 
        {
            get => id;
            set
            {
                id = value;
                NotifyOfPropertyChange(() => Id);                                           //그 속성이 값이 바뀌는걸 확인할때
                NotifyOfPropertyChange(() => CanSaveEmployee);
                NotifyOfPropertyChange(() => CanDeleteEmployee);
            }
        }

        
        public string EmpName 
        {
            get => empName ; 
            set
            {
                empName = value;
                NotifyOfPropertyChange(() => EmpName);
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }  
        }

        
        public decimal Salary 
        {
            get => salary;
            set
            {
                salary = value;
                NotifyOfPropertyChange(() => Salary);
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        
        public string DeptName 
        {
            get => deptName;
            set
            {
                deptName = value;
                NotifyOfPropertyChange(() => DeptName);
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        
        public string Destination
        {
            get => destination;
            set
            {
                destination = value;
                NotifyOfPropertyChange(() => Destination);
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        //전체 employees 리스트
        BindableCollection<EmployeesModel> employees;
        public BindableCollection<EmployeesModel> Employees {
            get => employees; 
            set
            {
                employees = value;
                NotifyOfPropertyChange(() => Employees);
            }
        }


        //리스트 중 선택된 하나의 employee
        EmployeesModel selectedEmployee;
       

        public EmployeesModel SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;

                if(value != null)
                {
                    Id = value.Id;
                    EmpName = value.EmpName;
                    Salary = value.Salary;
                    DeptName = value.DeptName;
                    Destination = value.Destination;
                }
                NotifyOfPropertyChange(() => SelectedEmployee);
            }
        }


        #endregion




        #region 사용자 함수
        public void NewEmployee()
        {
            Id = 0;
            EmpName = string.Empty;
            Salary = 0;
            DeptName = Destination = string.Empty;
        }

        private void GetEmployees()         //화면에 띄우는 함수
        {
            using (MySqlConnection conn = new MySqlConnection(CONSTRING))       //DB접속
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(EmployeesTbl.SELECT_EMPLOYEE, conn);                                              //(strQuery)만하면 절대 안된다!
                MySqlDataReader reader = cmd.ExecuteReader();
                Employees = new BindableCollection<EmployeesModel>();
                while(reader.Read())
                {
                    var temp = new EmployeesModel
                    {
                        Id = (int)reader["ID"],
                        EmpName = reader["EmpName"].ToString(),
                        Salary = (decimal)reader["Salary"],
                        DeptName = reader["DeptName"].ToString(),
                        Destination = reader["Destination"].ToString()
                    };
                    Employees.Add(temp);
                }
            }
        }
        public bool CanSaveEmployee
        {
            get => !(string.IsNullOrEmpty(EmpName) || string.IsNullOrEmpty(DeptName) || string.IsNullOrEmpty(Destination) || Salary == 0);
            //if (string.IsNullOrEmpty(EmpName) || string.IsNullOrEmpty(DeptName) || string.IsNullOrEmpty(Destination) || Salary == 0)
            //    return false;
            //else
            //    return true;
        }
        public void SaveEmployee()     //갱신하는 함수
        {
            int resultRow = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONSTRING))       //DB접속
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    if (Id == 0)  //insert
                        cmd.CommandText = EmployeesTbl.INSERT_EMPLOYEE;
                    else             //update
                        cmd.CommandText = EmployeesTbl.UPDATE_EMPLOYEE;

                    if (Id != 0)
                    {
                        MySqlParameter paramid = new MySqlParameter("@id", MySqlDbType.Int32);
                        paramid.Value = id;
                        cmd.Parameters.Add(paramid);
                    }
                    MySqlParameter paramEmpName = new MySqlParameter("@EmpName", MySqlDbType.VarChar, 45);
                    paramEmpName.Value = EmpName;
                    cmd.Parameters.Add(paramEmpName);

                    MySqlParameter paramSalary = new MySqlParameter("@Salary", MySqlDbType.Decimal);
                    paramSalary.Value = Salary;
                    cmd.Parameters.Add(paramSalary);

                    MySqlParameter paramDeptName = new MySqlParameter("@DeptName", MySqlDbType.VarChar, 45);
                    paramDeptName.Value = DeptName;
                    cmd.Parameters.Add(paramDeptName);

                    MySqlParameter paramDestination = new MySqlParameter("@Destination", MySqlDbType.VarChar, 45);
                    paramDestination.Value = Destination;
                    cmd.Parameters.Add(paramDestination);



                    resultRow = cmd.ExecuteNonQuery();
                }

                if (resultRow > 0)
                {
                    //MessageBox.Show("저장했습니다");

                    DialogViewModel dialogVM = new DialogViewModel();
                    dialogVM.DisplayName = "저장했습니당";
                    bool? success = windowManager.ShowDialog(dialogVM);
                    GetEmployees();                         //저장한 후 다시 나옴
                    NewEmployee();
                }
            }
            catch (System.Exception)
            {
                throw;
            }


        
        }


        public bool CanDeleteEmployee
        {
            get => !(Id == 0);
        }
        public void DeleteEmployee()
        {
            int resultRow = 0;
            using(MySqlConnection conn = new MySqlConnection(CONSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(EmployeesTbl.DELETE_EMPLOYEE,conn);
                cmd.Connection = conn;
                cmd.CommandText = EmployeesTbl.DELETE_EMPLOYEE;

                 MySqlParameter paramid = new MySqlParameter("@id", MySqlDbType.Int32);
                 paramid.Value = Id;
                 cmd.Parameters.Add(paramid);

                resultRow = cmd.ExecuteNonQuery();

            }
            if (resultRow > 0)
            {
                //MessageBox.Show("삭제했습니다");
                DialogViewModel dialogVM = new DialogViewModel();
                dialogVM.DisplayName = "삭제했습니당";
                bool? success = windowManager.ShowDialog(dialogVM);
                GetEmployees();                      
                NewEmployee();
            }


        }
        #endregion
    }
}
