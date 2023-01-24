using LumenWorks.Framework.IO.Csv;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testNo3.FORMS.Upload
{
    public partial class UploadModule : Form
    {
        public UploadModule()
        {
            InitializeComponent();
        }
        string filepath = null;
        public class SearchParameters
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string suffix { get; set; }
            public string Sex { get; set; }

            public string BirthDate { get; set; }
            public string BirthPlace { get; set; }

            public string Address { get; set; }

            public string parents { get; set; }
            public string Primary { get; set; }
            public string PSchoolYear { get; set; }
            public string Intermediate { get; set; }
            public string ISchoolYear { get; set; }
            public string HighSchool { get; set; }
            public string HSSchoolYear { get; set; }
            public string College { get; set; }
            public string CSchoolYear { get; set; }
            public string TittleDegree { get; set; }
            public string DateofGraduate { get; set; }
            public string SubjectCode { get; set; }
            public string SubjectNo { get; set; }
            public string DescriptiveTittle { get; set; }
            public string Semester { get; set; }
            public string SY { get; set; }
            public string FinalGrade { get; set; }
            public string ReExam { get; set; }
            public string Credit { get; set; }

            //public string number { get; set; }
        }
        List<SearchParameters> searchParameters = new List<SearchParameters>();
        private void iconButton1_Click(object sender, EventArgs e)
        {
            dgvUpload.Rows.Clear();
            dgvUpload.Refresh();

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Select files | *.csv;";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = Path.GetFileName(openFileDialog1.FileName);
                    string[] filetype = filename.Split('.');
                    txtfilename.Text = filename;
                    filepath = openFileDialog1.FileName;
                    //textBox3.Text = filetype[1];

                    //pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                    var csvTable = new DataTable();
                    using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@"" + filepath)), true))
                    {
                        csvTable.Load(csvReader);
                    }

                    searchParameters.Clear();

                    for (int i = 0; i < csvTable.Rows.Count; i++)
                    {

                        searchParameters.Add(new SearchParameters
                        {
                            LastName = csvTable.Rows[i][0].ToString(),
                            FirstName = csvTable.Rows[i][1].ToString(),
                            MiddleName = csvTable.Rows[i][2].ToString(),
                            suffix = csvTable.Rows[i][3].ToString(),
                            Sex = csvTable.Rows[i][4].ToString(),
                            BirthDate = csvTable.Rows[i][5].ToString(),
                            BirthPlace = csvTable.Rows[i][6].ToString(),
                            parents = csvTable.Rows[i][7].ToString(),
                            Address = csvTable.Rows[i][8].ToString(),
                            Primary = csvTable.Rows[i][9].ToString(),
                            PSchoolYear = csvTable.Rows[i][10].ToString(),
                            Intermediate = csvTable.Rows[i][11].ToString(),
                            ISchoolYear = csvTable.Rows[i][12].ToString(),
                            HighSchool = csvTable.Rows[i][13].ToString(),
                            HSSchoolYear = csvTable.Rows[i][14].ToString(),
                            College = csvTable.Rows[i][15].ToString(),
                            CSchoolYear = csvTable.Rows[i][16].ToString(),
                            TittleDegree = csvTable.Rows[i][17].ToString(),
                            DateofGraduate = csvTable.Rows[i][18].ToString(),
                            SubjectCode = csvTable.Rows[i][19].ToString(),
                            SubjectNo = csvTable.Rows[i][20].ToString(),
                            DescriptiveTittle = csvTable.Rows[i][21].ToString(),
                            Semester = csvTable.Rows[i][22].ToString(),
                            SY = csvTable.Rows[i][23].ToString(),
                            FinalGrade = csvTable.Rows[i][24].ToString(),
                            ReExam = csvTable.Rows[i][25].ToString(),
                            Credit = csvTable.Rows[i][26].ToString()



                        });
                        //searchParameters.Add(new SearchParameters { FirstName = csvTable.Rows[i][0].ToString(), MiddleName = csvTable.Rows[i][1].ToString(), LastName = csvTable.Rows[i][2].ToString(), GradeLevelID = csvTable.Rows[i][26].ToString(), GradeLevel = csvTable.Rows[i][27].ToString() });
                    }
                    int counter = 0;
                    foreach (var searchparameter in searchParameters)
                    {
                        try
                        {


                            dgvUpload.Rows.Add(
                                searchparameter.LastName,
                                searchparameter.FirstName,
                                searchparameter.MiddleName,
                                searchparameter.suffix,
                                searchparameter.Sex,
                                searchparameter.BirthDate,
                                searchparameter.BirthPlace,
                                searchparameter.parents,
                                searchparameter.Address,
                                searchparameter.Primary,
                                searchparameter.PSchoolYear,
                                searchparameter.Intermediate,
                                searchparameter.ISchoolYear,
                                searchparameter.HighSchool,
                                searchparameter.HSSchoolYear,
                                searchparameter.College,
                                searchparameter.CSchoolYear,
                                searchparameter.TittleDegree,
                                searchparameter.DateofGraduate,
                                searchparameter.SubjectCode,
                                searchparameter.SubjectNo,
                                searchparameter.DescriptiveTittle,
                                searchparameter.Semester,
                                searchparameter.SY,
                                searchparameter.FinalGrade,
                                searchparameter.ReExam,
                                searchparameter.Credit

                                );


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }




                        //this.dgItems.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        this.dgvUpload.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        this.dgvUpload.Columns[7].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        this.dgvUpload.Columns[8].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        this.dgvUpload.Columns[11].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        this.dgvUpload.Columns[13].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        this.dgvUpload.Columns[15].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        this.dgvUpload.Columns[17].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        this.dgvUpload.Columns[21].DefaultCellStyle.WrapMode = DataGridViewTriState.True;



                        this.dgvUpload.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;





                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {


        }
    }
}
