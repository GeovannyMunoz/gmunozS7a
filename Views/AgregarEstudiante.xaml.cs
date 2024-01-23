using System.Net;

namespace gmunozS7a.Views;

public partial class AgregarEstudiante : ContentPage
{
	public AgregarEstudiante()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient client = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
			parametros.Add("apellido", txtApellido.Text);
			parametros.Add("edad", txtEdad.Text);
			client.UploadValues("https://solinteg360.com/moviles/post.php", "POST", parametros);
			Navigation.PushAsync(new Inicio());
		}
		catch (Exception ex)
		{

			DisplayAlert("ERROR", ex.Message, "CERRAR");
		}

    }
}