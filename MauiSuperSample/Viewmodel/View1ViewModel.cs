using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MauiSuperSample.Util;
using Exception = System.Exception;


namespace MauiSuperSample.Viewmodel
{
    public partial class View1ViewModel : BaseViewModel
    {

        [ObservableProperty]
        string taskStatus;

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

        private void Completed() => TaskStatus = "Completed";

        private void Fail(Exception ex) => TaskStatus = ex.Message;
        
    }
}
