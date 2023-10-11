El director del departamento de Sistemas de la empresa donde usted se desempeña como colaborador le solicita implementar una aplicación con interfaz gráfica para controlar los gastos que realizan sus vendedores cada mes. 

La aplicación usará un archivo de texto para grabar los gastos de cada vendedor: “Gastos.txt” y una base de datos tipo Access para consultar la información de cada vendedor. La base de datos se llama “Vendedores.mdb” y la tabla que se necesita usar (Vendedor) posee los siguientes campos:
Campo:			Tipo de Dato:
Legajo			entero (es clave primaria)
Nombre		string

Los datos de los Gastos que se grabarán en el archivo se componen de estos campos:
IDGasto		entero, identificador del gasto
Legajo			entero legajo del vendedor
TipoGasto		string, nombre del gasto
Importe			float, costo del gasto.

Los tipos de gastos a usar por la aplicación son estos:
“Movilidad”, “Alquileres”, “Alojamiento”, “Comidas”

Funcionalidad requerida para el registro de datos:
En este formulario se deberá cargar con un procedimiento el comboBox de Vendedores, tomando los nombres desde la tabla Vendedor.
El comboBox con el tipo de gasto se debe cargar con estos items: “Movilidad”, “Alquileres”, “Alojamiento”, “Comidas”
El Identificador del gasto y el importe se ingresarán en los textBox correspondientes.

Los controles TextBox para ingresar los valores de ”Id Gasto” e “Importe” deben estar inicialmente en blanco.

Para grabar un registro de Gasto el usuario deberá ingresar el número del identificador del gasto, luego deberá seleccionar el nombre de un vendedor, a continuación, seleccionará un tipo de gasto. Finalmente ingresará el importe del gasto.

El importe debe ser mayor a cero.

El usuario podrá entonces guardar el registro con el botón “Guardar”, la aplicación debe controlar que el valor del identificador no se repita antes de grabar.

Si alguna de las condiciones de ingreso no se cumple se debe mostrar un mensaje informativo al usuario y no se permitirá ingresar el gasto. Después de cada registro el formulario volverá al estado inicial.

Tener en cuenta que, para registrar un gasto, se necesita conocer el Legajo del vendedor, ese valor se debe obtener de la misma tabla de Vendedor.

El valor del campo IDGasto debe ser un número entero mayor a cero.

El botón “Consultas” permitirá abrir un segundo formulario para realizar las consultas

Las opciones disponibles son:
-	Listado General de Gastos
-	Listado por tipo de Gasto

La primera opción mostrará el listado completo de todos los gastos registrados en el archivo de texto.

La segunda opción habilitará un control combobox para elegir el tipo de gasto a consultar, este combo estará cargado con los mismos valores que se muestran en el primer formulario. 

La consulta mostrará en la grilla solamente los gastos que tengan registrados tipos de gastos iguales al seleccionado en el combobox.

El botón “Consultar” ejecutará la consulta y mostrará en la grilla los registros que correspondan al criterio seleccionado. Además, deberá generar un archivo de texto con el nombre “Reporte.txt” que contenga en cada línea los mismos datos de cada fila de la grilla separados con coma.

Observar que la columna de la grilla “Nombre” corresponde al nombre del vendedor, cuyos valores no están en la tabla de Gastos y deben ser buscados en la tabla “Vendedor” usando su legajo.

Para todas las opciones de consulta se deberá calcular y mostrar el importe total de los gastos correspondientes a casa listado.

El botón “Cerrar” cierra la aplicación.

