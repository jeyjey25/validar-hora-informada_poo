namespace ConsoleApp.Modelos;

public class Compromisso
{
    private DateTime _data;
    private TimeSpan _hora;

    public string Data
    {
        get { return _data.ToString("dd/MM/yyyy"); }
        set
        {
            _validarDataInformada(value);
            _validarDataValidaParaCompromisso();
        }
    }

    public string Hora
    {
        get { return _hora.ToString(); }
        set
        {
            _validarHoraInformada(value);
        }
    }

    public string Descricao { get; set; }
    public string Local { get; set; }

    private void _validarDataInformada(string data)
    {
        if (!DateTime.TryParseExact(data,
                       "dd/MM/yyyy",
                       System.Globalization.CultureInfo.GetCultureInfo("pt-BR"),
                       System.Globalization.DateTimeStyles.None,
                       out _data))
        {
            throw new Exception($"Data {data} Inválida!");
        }
    }

    private void _validarDataValidaParaCompromisso()
    {
        if (_data < DateTime.Today)
        {
            throw new Exception($"Data {_data.ToString("dd/MM/yyyy")} é inferior à permitida.");
        }
    }

    private void _validarHoraInformada(string hora)
    {
        if (!TimeSpan.TryParse(hora, out _hora))
        {
            throw new Exception($"Hora {hora} inválida!");
        }

        if (_data.Date == DateTime.Today && _hora < DateTime.Now.TimeOfDay)
        {
            throw new Exception($"Hora {hora} já passou para o dia de hoje.");
        }
    }
}  