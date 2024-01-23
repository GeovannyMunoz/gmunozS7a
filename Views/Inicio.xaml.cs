using gmunozS7a.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace gmunozS7a.Views;

public partial class Inicio : ContentPage
{
	private const string Url = "https://solinteg360.com/moviles/post.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estudiante;
	
	public Inicio()
	{
		InitializeComponent();
		Obtener();
	}

	public async void Obtener()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> mostrarEstudiante = JsonConvert.DeserializeObject<List<Estudiante>>(content);
        estudiante = new ObservableCollection<Estudiante>(mostrarEstudiante);
		ListaEstudiantes.ItemsSource = estudiante;
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AgregarEstudiante());

    }

    private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new ActEliminar(objEstudiante));
    }
}