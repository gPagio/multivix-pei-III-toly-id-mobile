namespace TolyID.Helpers;

public class UiFactory
{
    public static Entry CriaEntryComTecladoNormal(object bindingContext, string caminhoDeBinding)
    {
        Entry entry = new Entry
        {
            Keyboard = Keyboard.Default,
            ReturnType = ReturnType.Next,
            TextColor = Color.FromArgb("#000000"),
            Placeholder = "Digite",
            BindingContext = bindingContext
        };

        entry.SetBinding(Entry.TextProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return entry;
    }

    public static Entry CriaEntryComTecladoNumerico(object bindingContext, string caminhoDeBinding)
    {
        Entry entry = new Entry
        {
            Keyboard = Keyboard.Numeric,
            ReturnType = ReturnType.Next,
            TextColor = Color.FromArgb("#000000"),
            Placeholder = "Digite",
            BindingContext = bindingContext
        };

        entry.SetBinding(Entry.TextProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return entry;
    }

    public static Editor CriaEditor(object bindingContext, string caminhoDeBinding)
    {
        Editor editor = new();
        editor.BindingContext = bindingContext;
        editor.TextColor = Color.FromArgb("#000000");
        editor.Placeholder = "Digite";
        editor.SetBinding(Editor.TextProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return editor;
    }

    public static DatePicker CriaDatePicker(object bindingContext, string caminhoDeBinding)
    {
        DatePicker datePicker = new();
        datePicker.BindingContext = bindingContext;
        datePicker.TextColor = Color.FromArgb("#000000");
        datePicker.SetBinding(DatePicker.DateProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return datePicker;
    }

    public static TimePicker CriaTimePicker(object bindingContext, string caminhoDeBinding)
    {
        TimePicker timePicker = new();
        timePicker.BindingContext = bindingContext;
        timePicker.TextColor = Color.FromArgb("#000000");
        timePicker.SetBinding(TimePicker.TimeProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return timePicker;
    }

    public static CheckBox CriaCheckBox(object bindingContext, string caminhoDeBinding)
    {
        CheckBox checkBox = new();
        checkBox.BindingContext = bindingContext;
        checkBox.SetBinding(CheckBox.IsCheckedProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return checkBox;
    }
}
