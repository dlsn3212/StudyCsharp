using MvvmDialogs.DialogTypeLocators;
using System;
using System.ComponentModel;

namespace MqttIoTMonitoringApp.Helpers
{
    public class DialogTypeLocator : IDialogTypeLocator
    {
        /// <summary>
        /// 특정 뷰 모델에다 Dialog타입을 위치시키는 메서드
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Type Locate(INotifyPropertyChanged viewModel)
        {
            Type viewModelType = viewModel.GetType();
            var DialogFullName = viewModelType.FullName;

            DialogFullName = DialogFullName.Substring(0, DialogFullName.Length - "Model".Length);


            return viewModelType.Assembly.GetType(DialogFullName);
        }
    }
}
