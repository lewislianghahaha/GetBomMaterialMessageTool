using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using GetBomMaterialMessageTool.Task;

namespace GetBomMaterialMessageTool
{
    public partial class Main : Form
    {
        #region 变量参数
        //记录EXCEL地址
        private string _fileadd;
        //获取运算过后的DT(导出时使用)
        private DataTable _generatedt;
        //记录初始化得出的物料DT
        private DataTable _materialdt;
        //获取初始化的BOM记录
        private DataTable _bomdt;
        #endregion

        SearchDb searchDb=new SearchDb();
        ImportDb importDb=new ImportDb();
        GenerateDb generateDb=new GenerateDb();
        ExportDb exportDb=new ExportDb();
        Load load=new Load();

        public Main()
        {
            InitializeComponent();
            OnInitialize();
            OnRegisterEvents();
        }

        //记录各初始化信息
        private void OnInitialize()
        {
            //初始化物料明细(导入时使用)
            OnInitializeMaterialDt();
            //初始化BOM明细(运算时使用)
            OnInitializeBomDt();
        }

        private void OnRegisterEvents()
        {
            btnimport.Click += Btnimport_Click;
            tmclose.Click += Tmclose_Click;
        }

        /// <summary>
        /// 初始化物料明细(导入时使用)
        /// </summary>
        private void OnInitializeMaterialDt()
        {
            _materialdt = searchDb.SearchMaterial();
        }

        /// <summary>
        /// 初始化BOM明细(运算时使用)
        /// </summary>
        private void OnInitializeBomDt()
        {
            _bomdt = searchDb.SearchBom();
        }

        /// <summary>
        /// 导入EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btnimport_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog { Filter = $"Xlsx文件|*.xlsx" };
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                _fileadd = openFileDialog.FileName;

                new Thread(Start).Start();
                load.StartPosition = FormStartPosition.CenterScreen;
                load.ShowDialog();

                //当完成后将相关记录导出至EXCEL
                var saveFileDialog = new SaveFileDialog { Filter = $"Xlsx文件|*.xlsx" };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileAdd = saveFileDialog.FileName;
                    exportDb.ExportDtToExcel(fileAdd, _generatedt);
                    //完成后关闭窗体
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmclose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 子线程运行
        /// </summary>
        private void Start()
        {
            Genearte();

            //当完成后将Form2子窗体关闭
            this.Invoke((ThreadStart)(() =>
            {
                load.Close();
            }));
        }

        /// <summary>
        /// 导入及运算
        /// </summary>
        private void Genearte()
        {
            //将相关信息放到导入方法内
            var importdt = importDb.ImportExcelToDt(_materialdt, _fileadd);
            //执行运算
            _generatedt = generateDb.Generatedt(_bomdt,importdt);
        }

    }
}
