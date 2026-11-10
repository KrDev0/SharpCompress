using System.Collections.Generic;
using System.Windows.Forms;

namespace _7ZipSharp
{
    internal static class Localization
    {
        private static readonly Dictionary<string, string> English = new Dictionary<string, string>
        {
            { "Abrir archivo", "Open archive" }, { "Comprimir carpeta", "Compress folder" },
            { "Crear archivo", "Create archive" }, { "Extraer", "Extract" }, { "Extraer todo", "Extract all" },
            { "Extraer selección", "Extract selection" }, { "Probar integridad", "Test archive" },
            { "Vista", "View" }, { "Detalles", "Details" }, { "Lista", "List" },
            { "Iconos", "Icons" }, { "Iconos grandes", "Large icons" }, { "Mosaico", "Tiles" },
            { "Acerca de", "About" }, { "Configuración", "Settings" },
            { "UBICACIONES", "LOCATIONS" }, { "Nombre", "Name" },
            { "Tipo", "Type" }, { "Tamaño", "Size" }, { "Modificado", "Modified" },
            { "Listo", "Ready" }, { "Cerrar", "Close" }, { "Cancelar", "Cancel" },
            { "Comprimir", "Compress" }, { "Examinar…", "Browse…" }, { "Examinar...", "Browse..." },
            { "Comprimir como SCZ (SharpCompress)", "Compress as SCZ (SharpCompress)" },
            { "Segundo plano", "Run in background" }, { "Formato:", "Format:" }, { "Método:", "Method:" },
            { "Nivel:", "Level:" }, { "Perfil:", "Profile:" }, { "Guardar archivo en:", "Save archive to:" },
            { "Elementos a comprimir:", "Items to compress:" }, { "Agregar carpeta", "Add folder" },
            { "Agregar archivos", "Add files" }, { "Proteger con contraseña", "Protect with password" },
            { "Contraseña:", "Password:" }, { "Confirmar:", "Confirm:" }, { "Mostrar contraseña", "Show password" },
            { "Seguridad del archivo", "Archive security" }, { "Cifrar nombres de ficheros (7z/SCZ)", "Encrypt file names (7z/SCZ)" },
            { "Dividir en volúmenes (7z/SCZ)", "Split into volumes (7z/SCZ only)" },
            { "Volumen personalizado", "Custom volume size" }, { "Mantener directorio raíz", "Keep root folder" },
            { "Remover elemento", "Remove item" }, { "Verificación de integridad", "Archive integrity check" },
            { "Elemento", "Item" }, { "Resultado", "Result" },
            { "Correcto", "Passed" }, { "Error", "Failed" },
            { "Elemento desconocido", "Unknown item" },
            { "Preparando la verificación…", "Preparing verification…" },
            { "Leyendo y comprobando los datos del archivo…", "Reading and checking archive data…" },
            { "Datos descomprimidos y verificados.", "Data extracted and verified." },
            { "No se pudo completar la verificación. Comprueba el archivo y la contraseña.", "Verification could not be completed. Check the archive and password." },
            { "Verificación cancelada.", "Verification cancelled." },
            { "Ingresar contraseña", "Enter password" }, { "Aceptar", "OK" },
            { "Sí", "Yes" }, { "No", "No" }, { "Sí a todo", "Yes to all" },
            { "Reemplazar", "Replace" }, { "Omitir", "Skip" }, { "Archivo existente", "File already exists" },
            { "Archivo a extraer:", "Archive to extract:" }, { "Extraer en:", "Extract to:" },
            { "Extraer aquí", "Extract here" }, { "Si ya existe:", "If a file already exists:" },
            { "Términos de uso", "Terms of use" }, { "Acerca de SharpCompress", "About SharpCompress" },
            { "Versión: ", "Version: " }, { "Aplicación para gestionar archivos comprimidos", "Archive management application" },
            { "Creado por KrDev", "Created by KrDev" }, { "Formatos: 7z · ZIP · TAR · GZip", "Formats: 7z · ZIP · TAR · GZip" },
            { "Motores: 7-Zip y SharpCompress", "Engines: 7-Zip and SharpCompress" },
            { "Copyright © 2023–2026 KrDev", "Copyright © 2023–2026 KrDev" },
            { "Formatos: 7z · SCZ · ZIP · TAR · GZip · SFX Windows", "Formats: 7z · SCZ · ZIP · TAR · GZip · Windows SFX" },
            { "Carpetas frecuentes", "Quick access" }, { "Este equipo", "This PC" },
            { "Inicio", "Home" }, { "Ir", "Go" }, { "Ubicaciones", "Locations" },
            { "Preguntar en cada conflicto", "Ask for each conflict" },
            { "Reemplazar archivos existentes", "Replace existing files" },
            { "Omitir archivos existentes", "Skip existing files" },
            { "Conservar ambos archivos", "Keep both files" },
            { "Equilibrado", "Balanced" }, { "Rápido", "Fast" }, { "Más rápido", "Fastest" },
            { "Menor tamaño", "Smallest size" },
            { "Personalizado", "Custom" }, { "Ninguno", "None" }, { "Bajo", "Low" },
            { "Normal", "Normal" }, { "Alto", "High" }, { "Ultra", "Ultra" }, { "Deflate (Por defecto)", "Deflate (default)" },
            { "LZMA2 (Por defecto)", "LZMA2 (default)" }, { "GNU (Por defecto)", "GNU (default)" },
            { "Preparando archivos…", "Preparing files…" }, { "Compresión en curso…", "Compressing…" },
            { "Extracción completada.", "Extraction completed." }, { "Preparando extracción…", "Preparing extraction…" },
            { "Analizando archivo…", "Analyzing archive…" }, { "Listo para extraer.", "Ready to extract." },
            { "Compresión cancelada.", "Compression cancelled." }, { "La compresión no se completó.", "Compression did not complete." },
            { "Extracción cancelada entre elementos.", "Extraction cancelled between items." },
            { "Extracción cancelada por conflicto.", "Extraction cancelled due to a conflict." },
            { "La extracción no se completó.", "Extraction did not complete." },
            { "Cancelando… se detendrá al terminar el elemento actual.", "Cancelling… the current item will finish first." },
            { "Sin compresión: máxima velocidad y archivos más grandes.", "No compression: fastest processing and larger archives." },
            { "Rápido: menos tiempo de espera, con menor reducción del tamaño.", "Fast: less waiting, with less size reduction." },
            { "Ligero: compresión moderada y consumo contenido.", "Low: moderate compression with modest resource use." },
            { "Normal: equilibrio recomendado entre velocidad y tamaño.", "Normal: recommended balance between speed and size." },
            { "Alto: reduce más el tamaño y tarda más.", "High: smaller archives, with longer processing." },
            { "Máximo: prioriza el tamaño y puede usar más memoria.", "Ultra: prioritizes size and may use more memory." },
            { "TAR solo empaqueta: no aplica compresión, contraseña ni división en volúmenes.", "TAR only packages files; it does not support compression, passwords, or volumes." },
            { "GZip comprime un único archivo; no admite contraseña ni división en volúmenes.", "GZip compresses one file and does not support passwords or volumes." },
            { "Los perfiles aplican un nivel recomendado. Al cambiar el nivel o el método, el perfil pasa a Personalizado.", "Profiles choose a recommended level. Changing the level or method switches to Custom." },
            { "Crear autoextractor (.exe)", "Create self-extracting archive (.exe)" },
            { "Configurar…", "Configure…" },
            { "Opciones del autoextractor", "Self-extracting archive options" },
            { "Define el título, el destino, el mensaje y las acciones opcionales del autoextractor.", "Set the self-extracting archive title, destination, message, and optional actions." },
            { "Título", "Title" }, { "Carpeta de extracción", "Extraction folder" },
            { "Mensaje inicial (opcional)", "Opening message (optional)" },
            { "Ejecutar al terminar (opcional)", "Run after extraction (optional)" },
            { "Mostrar interfaz de extracción", "Show extraction interface" },
            { "Escribe un título para el autoextractor.", "Enter a title for the self-extracting archive." },
            { "Indica una carpeta de destino o usa . para la carpeta actual.", "Enter a destination folder or use . for the current folder." },
            { "Los campos no pueden contener saltos de línea.", "Fields cannot contain line breaks." },
            { "Creando el autoextractor…", "Building self-extracting archive…" },
            { "Personaliza el destino, las acciones y la apariencia del paquete autoextraíble.", "Customize the destination, actions, and appearance of the self-extracting package." },
            { "Paquete y destino", "Package and destination" },
            { "Experiencia de extracción", "Extraction experience" },
            { "Apariencia", "Appearance" },
            { "Icono propio del archivo .exe SFX", "Custom icon for the SFX .exe file" },
            { "Seleccionar icono para el autoextractor", "Select an icon for the self-extracting archive" },
            { "Selecciona la carpeta donde se extraerá el contenido.", "Select the folder where the content will be extracted." },
            { "La carpeta de extracción seleccionada ya no existe.", "The selected extraction folder no longer exists." },
            { "Ejecutable al terminar (archivo incluido o ruta dentro del archivo)", "Run after extraction (included file or path inside the archive)" },
            { "No se pudieron analizar los ejecutables de las fuentes seleccionadas.", "Could not scan the selected sources for executable files." },
            { "Quitar", "Clear" }, { "Aplicar", "Apply" },
            { "No se encontró el icono SFX seleccionado.", "The selected SFX icon was not found." },
            { "El archivo seleccionado no es un icono ICO válido.", "The selected file is not a valid ICO icon." },
            { "Selecciona un archivo ICO válido.", "Select a valid ICO file." },
            { "Selecciona la carpeta de destino:", "Select the destination folder:" },
            { "Autoextractores de Windows", "Windows self-extracting archives" },
            { "Configuración de SharpCompress", "SharpCompress settings" },
            { "General", "General" }, { "Compresión", "Compression" }, { "Extracción", "Extraction" },
            { "Explorer", "Explorer" }, { "Tema", "Theme" }, { "Claro", "Light" }, { "Oscuro", "Dark" },
            { "Idioma", "Language" }, { "Vista de archivos", "File list view" },
            { "Icono del menú contextual", "Context menu icon" },
            { "Restaurar", "Restore" }, { "Abrir carpeta de registros", "Open log folder" },
            { "Restaurar preferencias predeterminadas", "Restore default preferences" },
            { "Formato predeterminado", "Default format" }, { "Perfil predeterminado", "Default profile" },
            { "Crear autoextractor de Windows por defecto", "Create a Windows self-extracting archive by default" },
            { "Carpeta predeterminada de salida", "Default output folder" },
            { "Carpeta predeterminada de extracción", "Default extraction folder" },
            { "Al encontrar archivos existentes", "When files already exist" },
            { "Administra la integración del menú contextual de Windows. Reparar vuelve a registrar las opciones y actualiza el icono. Desactivar elimina las entradas de SharpCompress.", "Manage the Windows context menu integration. Repair registers the options again and updates the icon. Disable removes SharpCompress entries." },
            { "Estado de la integración", "Integration status" },
            { "La reparación requiere confirmar el aviso de permisos de Windows. El cambio se aplica a todo el equipo.", "Repair requires approval in the Windows permission prompt. The change applies to the whole computer." },
            { "Reparar / activar integración", "Repair / enable integration" },
            { "Desactivar integración", "Disable integration" },
            { "Formatos comprimidos predeterminados", "Default archive formats" },
            { "Registra SharpCompress para formatos de archivo y abre la configuración de Windows para elegir cuáles serán predeterminados.", "Register SharpCompress for archive formats, then open Windows Settings to choose which formats it handles by default." },
            { "Elegir formatos predeterminados…", "Choose default formats…" },
            { "No se pudo abrir la configuración de aplicaciones predeterminadas de Windows.", "Could not open Windows default app settings." },
            { "La integración de Explorer está activa en este equipo.", "Explorer integration is active on this computer." },
            { "La integración de Explorer no está activa en este equipo.", "Explorer integration is not active on this computer." },
            { "Esperando la confirmación de Windows…", "Waiting for Windows approval…" },
            { "No se hicieron cambios: se canceló la solicitud de permisos.", "No changes were made: the permission request was cancelled." },
            { "No se pudo actualizar la integración. Consulta el registro de errores.", "The integration could not be updated. Check the error log." },
            { "Integración del menú contextual reparada correctamente.", "Context menu integration was repaired successfully." },
            { "Se quitó la integración del menú contextual de este equipo.", "Context menu integration was removed from this computer." },
            { "¿Restaurar las preferencias predeterminadas de SharpCompress?", "Restore SharpCompress default preferences?" },
            { "No se encuentra el archivo de icono seleccionado.", "The selected icon file cannot be found." },
            { "Selecciona un archivo de icono .ico válido.", "Select a valid .ico icon file." },
            { "Seleccionar icono", "Select icon" },
            { "La carpeta de salida no existe.", "The output folder does not exist." },
            { "La carpeta de extracción no existe.", "The extraction folder does not exist." },
            { "Seleccionar carpeta predeterminada de salida", "Select default output folder" },
            { "Seleccionar carpeta predeterminada de extracción", "Select default extraction folder" },
            { "No se pudo abrir la carpeta de registros.", "Could not open the log folder." },
            { " 7z admite AES-256 y volúmenes.", " 7z supports AES-256 and split volumes." },
            { " ZIP admite ZipCrypto o AES; no admite volúmenes aquí.", " ZIP supports ZipCrypto or AES; split volumes are unavailable." },
            { " SCZ es el formato SharpCompress basado en 7z: LZMA2, AES-256, cifrado de nombres y volúmenes.", " SCZ is SharpCompress's 7z-based format: LZMA2, AES-256, encrypted headers, and split volumes." }
        };

        internal static bool IsEnglish
        {
            get { return _7ZipSharp.Properties.Settings.Default.UiLanguage == "en"; }
        }

        internal static void Apply(Control control)
        {
            if (control == null) return;
            ApplyControl(control);
        }

        internal static void SetLanguage(string language)
        {
            _7ZipSharp.Properties.Settings.Default.UiLanguage = language == "en" ? "en" : "es";
            try { _7ZipSharp.Properties.Settings.Default.Save(); }
            catch (System.Configuration.ConfigurationErrorsException ex) { ErrorLogger.Write(ex, "Saving language preference"); }
            catch (System.IO.IOException ex) { ErrorLogger.Write(ex, "Saving language preference"); }
        }

        internal static string TranslateText(string value)
        {
            return Translate(value);
        }

        private static void ApplyControl(Control control)
        {
            control.Text = Translate(control.Text);
            var combo = control as ComboBox;
            if (combo != null)
            {
                int selectedIndex = combo.SelectedIndex;
                for (int index = 0; index < combo.Items.Count; index++)
                {
                    string itemText = combo.Items[index] as string;
                    if (itemText != null) combo.Items[index] = Translate(itemText);
                }
                if (selectedIndex >= 0 && selectedIndex < combo.Items.Count) combo.SelectedIndex = selectedIndex;
            }
            var listView = control as ListView;
            if (listView != null)
                foreach (ColumnHeader column in listView.Columns) column.Text = Translate(column.Text);
            foreach (Control child in control.Controls) ApplyControl(child);
            var tree = control as TreeView;
            if (tree != null)
                foreach (TreeNode node in tree.Nodes) ApplyNode(node);
            var strip = control as ToolStrip;
            if (strip != null)
                foreach (ToolStripItem item in strip.Items) ApplyItem(item);
            if (control.ContextMenuStrip != null) ApplyControl(control.ContextMenuStrip);
        }

        private static void ApplyItem(ToolStripItem item)
        {
            item.Text = Translate(item.Text);
            var dropDown = item as ToolStripDropDownItem;
            if (dropDown != null)
                foreach (ToolStripItem child in dropDown.DropDownItems) ApplyItem(child);
        }

        private static void ApplyNode(TreeNode node)
        {
            node.Text = Translate(node.Text);
            foreach (TreeNode child in node.Nodes) ApplyNode(child);
        }

        private static string Translate(string value)
        {
            string translated;
            if (value == null) return null;
            if (IsEnglish && value.StartsWith("Comprimir a ", System.StringComparison.Ordinal))
                return "Compress to " + value.Substring("Comprimir a ".Length);
            if (IsEnglish && value.StartsWith("Comprimir ", System.StringComparison.Ordinal))
                return "Compress " + value.Substring("Comprimir ".Length);
            if (IsEnglish && value.StartsWith("Extractor | ", System.StringComparison.Ordinal))
                return "Extractor | " + value.Substring("Extractor | ".Length);
            if (IsEnglish && value.StartsWith("Versión: ", System.StringComparison.Ordinal))
                return "Version: " + value.Substring("Versión: ".Length);
            if (IsEnglish && value.StartsWith("Arquitectura: ", System.StringComparison.Ordinal))
                return "Architecture: " + value.Substring("Arquitectura: ".Length);
            if (IsEnglish && value.StartsWith("Nombre del archivo: ", System.StringComparison.Ordinal))
                return "Archive name: " + value.Substring("Nombre del archivo: ".Length);
            if (IsEnglish && value.StartsWith("Comprimir archivo ", System.StringComparison.Ordinal))
                return "Compressing item " + value.Substring("Comprimir archivo ".Length).Replace(" de ", " of ");
            if (IsEnglish && value.StartsWith("Comprimiendo archivo ", System.StringComparison.Ordinal))
                return "Compressing item " + value.Substring("Comprimiendo archivo ".Length).Replace(" de ", " of ");
            if (IsEnglish && value.StartsWith("Extrayendo archivo ", System.StringComparison.Ordinal))
                return "Extracting item " + value.Substring("Extrayendo archivo ".Length).Replace(" de ", " of ");
            if (IsEnglish && value.StartsWith("Comprimiendo… ", System.StringComparison.Ordinal))
                return "Compressing… " + value.Substring("Comprimiendo… ".Length);
            if (IsEnglish && value.StartsWith("Extrayendo… ", System.StringComparison.Ordinal))
                return "Extracting… " + value.Substring("Extrayendo… ".Length);
            if (IsEnglish && value.StartsWith("Error al extraer: ", System.StringComparison.Ordinal))
                return "Extraction failed: " + value.Substring("Error al extraer: ".Length);
            if (IsEnglish && value.StartsWith("Extracción cancelada entre ", System.StringComparison.Ordinal))
                return "Extraction cancelled between " + value.Substring("Extracción cancelada entre ".Length).Replace("elementos", "items");
            if (IsEnglish && value.StartsWith("Completado: ", System.StringComparison.Ordinal))
                return "Completed: " + value.Substring("Completado: ".Length).Replace("del original", "of original");
            if (IsEnglish && value.StartsWith("Finalizada con ", System.StringComparison.Ordinal))
                return "Finished with " + value.Substring("Finalizada con ".Length);
            if (IsEnglish && value.StartsWith("Omitidos: ", System.StringComparison.Ordinal))
                return "Skipped: " + value.Substring("Omitidos: ".Length);
            if (IsEnglish && value.StartsWith("Verificando… ", System.StringComparison.Ordinal))
                return "Verifying… " + value.Substring("Verificando… ".Length);
            if (IsEnglish && value.EndsWith(" elementos", System.StringComparison.Ordinal))
                return value.Substring(0, value.Length - " elementos".Length) + " items";
            if (IsEnglish) return English.TryGetValue(value, out translated) ? translated : value;
            foreach (KeyValuePair<string, string> pair in English)
                if (pair.Value == value) return pair.Key;
            return value;
        }
    }
}
