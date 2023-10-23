using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MauiSuperSample.Util;
using MauiSuperSample.View;
using Exception = System.Exception;



namespace MauiSuperSample.Viewmodel
{
    //O valor é recebido por Navegacão.
    [QueryProperty(nameof(TaskStatusName), "TaskStatusName")]

    public partial class View1ViewModel : BaseViewModel
    {

        [ObservableProperty]
        string taskStatusName;



        //NotifyCanExecuteChangedFor vai notificar o command executando o CanNavigateView2
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(GoView2Command))] 
        string sayMyName = "Heisenberg";


        public View1ViewModel() => DoSomethingExtensivel().Await(Completed, Fail);

        async Task DoSomethingExtensivel()
        {
            try
            {
                await Task.Delay(3000);
                //será chamado o método Completed
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //será chamado o método Fail
                //throw new Exception("Calls Fail Method");
                throw;
            }
        }

        private void Completed() => TaskStatusName = "Completed";

        private void Fail(Exception ex) => TaskStatusName = ex.Message;


        [RelayCommand(CanExecute = nameof(CanNavigateView2))]
        async Task GoView2() => await Shell.Current.GoToAsync(nameof(View2), true);

        private bool CanNavigateView2() => SayMyName == "Heisenberg";

    }
}
