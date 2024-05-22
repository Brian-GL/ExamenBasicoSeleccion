using ApiExamen;
using ApiExamen.Models;
using ApiExamen.Models.Examen;

namespace ExamenBasicoSeleccion
{
    public partial class MainForm : Form
    {
        private readonly ClsExamen _ClsExamen;

        public MainForm()
        {
            _ClsExamen = new ClsExamen();
            InitializeComponent();
            dataGridViewExamen.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewExamen.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewExamen.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewExamen.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.Black;
        }

        private void comboBoxAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxAccion.SelectedIndex)
            {
                // Crear
                case 0:
                case 1:
                    labelIdExamen.Visible = false;
                    numericUpDownIdExamen.Visible = false;
                    textBoxNombre.Visible = true;
                    textBoxDescripcion.Visible = true;
                    labelDescripcion.Visible = true;
                    labelNombre.Visible = true;
                    break;
                case 2:
                case 3:
                case 4:
                case 5: // Actualizar y obtener
                    labelIdExamen.Visible = true;
                    numericUpDownIdExamen.Visible = true;
                    textBoxNombre.Visible = true;
                    textBoxDescripcion.Visible = true;
                    labelDescripcion.Visible = true;
                    labelNombre.Visible = true;
                    break;
                case 6:
                case 7: // Eliminar
                    labelIdExamen.Visible = true;
                    numericUpDownIdExamen.Visible = true;
                    textBoxNombre.Visible = false;
                    textBoxDescripcion.Visible = false;
                    labelNombre.Visible = false;
                    labelDescripcion.Visible = false;
                    break;
            }
        }

        private async void buttonAccion_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                switch (comboBoxAccion.SelectedIndex)
                {
                    // Crear DLL
                    case 0:
                        await CrearExamenPorDLLAsync();
                        break;
                    case 1: // Crear WS
                        await CrearExamenPorWsAsync();
                        break;
                    case 2: // Actualizar por DLL
                        await ActualizarExamenPorDLLAsync();
                        break; 
                    case 3: // Actualizar por Ws
                        await ActualizarExamenPorWsAsync();
                        break;
                    case 4: // Obtener por DLL
                        await ObtenerExamenesPorDLLAsync();
                        break; 
                    case 5: // Obtener por WS
                        await ObtenerExamenesPorWsAsync();
                        break;
                    case 6: // Eliminar por DLL
                        await EliminarExamenPorDLLAsync();
                        break; 
                    case 7: // Eliminar por Ws
                        await EliminarExamenPorWsAsync();
                        break;

                }
            }
        }

        public async Task CrearExamenPorDLLAsync()
        {
            CreateExamenRequest request = new()
            {
                Nombre = textBoxNombre.Text,
                Descripcion = textBoxDescripcion.Text
            };

            InfrastructureResponse response = await _ClsExamen.CreateExamenAsync(request);

            if (response.Success)
            {
                MessageBox.Show(text: response.Message, caption: "Crear exámen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ObtenerTodosExamenesPorDLLAsync();
            }
            else
            {
                MessageBox.Show(text: response.Message, caption: "Crear exámen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task CrearExamenPorWsAsync()
        {
            CreateExamenRequest request = new()
            {
                Nombre = textBoxNombre.Text,
                Descripcion = textBoxDescripcion.Text
            };

            InfrastructureResponse response = await _ClsExamen.CreateWsExamenAsync(request);

            if (response.Success)
            {
                MessageBox.Show(text: response.Message, caption: "Crear exámen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ObtenerTodosExamenesPorWsAsync();
            }
            else
            {
                MessageBox.Show(text: response.Message, caption: "Crear exámen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task ActualizarExamenPorDLLAsync()
        {
            UpdateExamenRequest request = new()
            {
                IdExamen = (int)numericUpDownIdExamen.Value,
                Nombre = textBoxNombre.Text,
                Descripcion = textBoxDescripcion.Text
            };

            InfrastructureResponse response = await _ClsExamen.UpdateExamenAsync(request);

            if (response.Success)
            {
                MessageBox.Show(text: response.Message, caption: "Actualizar exámen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ObtenerTodosExamenesPorDLLAsync();
            }
            else
            {
                MessageBox.Show(text: response.Message, caption: "Actualizar exámen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task ActualizarExamenPorWsAsync()
        {
            UpdateExamenRequest request = new()
            {
                IdExamen = (int)numericUpDownIdExamen.Value,
                Nombre = textBoxNombre.Text,
                Descripcion = textBoxDescripcion.Text
            };

            InfrastructureResponse response = await _ClsExamen.UpdateWsExamenAsync(request);

            if (response.Success)
            {
                MessageBox.Show(text: response.Message, caption: "Actualizar exámen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ObtenerTodosExamenesPorWsAsync();
            }
            else
            {
                MessageBox.Show(text: response.Message, caption: "Actualizar exámen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task EliminarExamenPorDLLAsync()
        {
            DeleteExamenRequest request = new()
            {
                IdExamen = (int)numericUpDownIdExamen.Value
            };

            InfrastructureResponse response = await _ClsExamen.DeleteExamenAsync(request);

            if (response.Success)
            {
                MessageBox.Show(text: response.Message, caption: "Eliminar exámen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ObtenerTodosExamenesPorDLLAsync();
            }
            else
            {
                MessageBox.Show(text: response.Message, caption: "Eliminar exámen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task EliminarExamenPorWsAsync()
        {
            DeleteExamenRequest request = new()
            {
                IdExamen = (int)numericUpDownIdExamen.Value
            };

            InfrastructureResponse response = await _ClsExamen.DeleteWsExamenAsync(request);

            if (response.Success)
            {
                MessageBox.Show(text: response.Message, caption: "Eliminar exámen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ObtenerTodosExamenesPorWsAsync();
            }
            else
            {
                MessageBox.Show(text: response.Message, caption: "Eliminar exámen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task ObtenerExamenesPorDLLAsync()
        {
            var request = new GetExamenRequest()
            {
                IdExamen = ((int)numericUpDownIdExamen.Value) == 0 ? null : (int)numericUpDownIdExamen.Value,
                Nombre = string.IsNullOrEmpty(textBoxNombre.Text) ? null : textBoxNombre.Text,
                Descripcion = string.IsNullOrEmpty(textBoxDescripcion.Text) ? null : textBoxDescripcion.Text
            };

            InfrastructureResponse response = await _ClsExamen.GetExamenesAsync(request);
            dataGridViewExamen.Rows.Clear();

            if (response.Success)
            {
                List<GetExamenBdResponse> _Examenes = (response.Value as List<GetExamenBdResponse>)!;

                foreach (GetExamenBdResponse item in _Examenes)
                    dataGridViewExamen.Rows.Add(item.IdExamen, item.Nombre, item.Descripcion);
            }
            else
            {
                MessageBox.Show(text: response.Message, caption: "Obtener exámenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public async Task ObtenerExamenesPorWsAsync()
        {
            var request = new GetExamenRequest()
            {
                IdExamen = ((int)numericUpDownIdExamen.Value) == 0 ? null : (int)numericUpDownIdExamen.Value,
                Nombre = string.IsNullOrEmpty(textBoxNombre.Text) ? null : textBoxNombre.Text,
                Descripcion = string.IsNullOrEmpty(textBoxDescripcion.Text) ? null : textBoxDescripcion.Text
            };

            InfrastructureResponse response = await _ClsExamen.GetWsExamenesAsync(request);

            dataGridViewExamen.Rows.Clear();

            if (response.Success)
            {
                List<GetExamenBdResponse> _Examenes = (response.Value as List<GetExamenBdResponse>)!;

                foreach (GetExamenBdResponse item in _Examenes)
                    dataGridViewExamen.Rows.Add(item.IdExamen, item.Nombre, item.Descripcion);
            }
            else
            {
                MessageBox.Show(text: response.Message, caption: "Obtener exámenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public async Task ObtenerTodosExamenesPorDLLAsync()
        {
            InfrastructureResponse response = await _ClsExamen.GetExamenesAsync(new GetExamenRequest());

            dataGridViewExamen.Rows.Clear();

            if (response.Success)
            {
                List<GetExamenBdResponse> _Examenes = (response.Value as List<GetExamenBdResponse>)!;

                foreach (GetExamenBdResponse item in _Examenes)
                    dataGridViewExamen.Rows.Add(item.IdExamen, item.Nombre, item.Descripcion);
            }
            else
            {
                MessageBox.Show(text: response.Message, caption: "Obtener exámenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public async Task ObtenerTodosExamenesPorWsAsync()
        {
            InfrastructureResponse response = await _ClsExamen.GetWsExamenesAsync(new GetExamenRequest());

            dataGridViewExamen.Rows.Clear();

            if (response.Success)
            {
                List<GetExamenBdResponse> _Examenes = (response.Value as List<GetExamenBdResponse>)!;

                foreach (GetExamenBdResponse item in _Examenes)
                    dataGridViewExamen.Rows.Add(item.IdExamen, item.Nombre, item.Descripcion);
            }
            else
            {
                MessageBox.Show(text: response.Message, caption: "Obtener exámenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ClsExamen.Dispose();
        }
    }
}
