using App.Core;
using App.Core.Brigde;
using App.Core.DataParser;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Presenter.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presenter
{
   public partial class MainWindow : Form
   {
      private readonly GViewer m_gViewer;

      private List<CpmGraph> m_loadedGraphs;

      private CpmGraph m_currentDisplayed;

      private CpmGraphFacade m_cpmGraphFacade;

      private bool m_isNewElementAdded = false;

      #region [Form Configuration]

      public MainWindow()
      {
         InitializeComponent();
         m_loadedGraphs = new List<CpmGraph>();
         m_cpmGraphFacade = new CpmGraphFacade();
         m_gViewer = PrepareViewer();
         panel.BackColor = System.Drawing.Color.Gray;
         panel.Controls.Add(m_gViewer);
         btnRefresh.Enabled = false;
         btnDrawCriticalPath.Enabled = false;
         FormBorderStyle = FormBorderStyle.FixedSingle;
      }

      private GViewer PrepareViewer()
      {
         var gv = new GViewer();
         gv.Dock = DockStyle.Fill;
         var toolbar = gv.Controls[1] as ToolBar;
         (toolbar.Buttons["homeZoomButton"] as ToolBarButton).Visible = true;
         (toolbar.Buttons["zoomin"] as ToolBarButton).Visible = true;
         (toolbar.Buttons["zoomout"] as ToolBarButton).Visible = true;
         (toolbar.Buttons["windowZoomButton"] as ToolBarButton).Visible = false;
         (toolbar.Buttons["panButton"] as ToolBarButton).Visible = false;
         (toolbar.Buttons["backwardButton"] as ToolBarButton).Visible = false;
         (toolbar.Buttons["forwardButton"] as ToolBarButton).Visible = false;
         (toolbar.Buttons["saveButton"] as ToolBarButton).Visible = false;
         (toolbar.Buttons["undoButton"] as ToolBarButton).Visible = false;
         (toolbar.Buttons["redoButton"] as ToolBarButton).Visible = false;
         (toolbar.Buttons["openButton"] as ToolBarButton).Visible = false;
         (toolbar.Buttons["print"] as ToolBarButton).Visible = false;
         (toolbar.Buttons["layoutSettingsButton"] as ToolBarButton).Visible = false;
         (toolbar.Buttons["edgeInsertButton"] as ToolBarButton).Visible = false;
         return gv;
      }

      #endregion [Form Configuration]

      #region [Controls Event Section]

      private void LoadFileButtonClicked(object sender, System.EventArgs e)
      {
         if (openFile.ShowDialog() == DialogResult.OK)
         {
            var cpm = CpmGraph.Create(m_cpmGraphFacade.CreateGraphFromFile(openFile.FileName));
            m_currentDisplayed = cpm;
            m_loadedGraphs.Add(cpm);
            RefreshViewer(cpm.Graph);
            m_isNewElementAdded = true;

            RefreshLoadedGraphsComboBox();
            btnRefresh.Enabled = true;
            btnDrawCriticalPath.Enabled = true;
         }
      }

      private void RefreshButtonClicked(object sender, System.EventArgs e)
      {
         if (m_currentDisplayed.Graph == null)
            return;
         RefreshViewer(m_currentDisplayed.Graph);
      }

      private void LoadedGraphsSelectedIndexChanged(object sender, System.EventArgs e)
      {
         var name = (sender as ComboBox).Text;
         // puste gdy dodawany nowy element, bo nullowane DataSource wywołuje ten event
         if (string.IsNullOrEmpty(name))
            return;

         if (name != m_currentDisplayed.Name && m_isNewElementAdded)
         {
            (sender as ComboBox).SelectedItem = m_currentDisplayed;
            m_isNewElementAdded = false;
         }
         else
         {
            var selectedGraph = m_loadedGraphs.Single(g => g.Name == name);
            m_currentDisplayed = selectedGraph;
         }

         RefreshViewer(m_currentDisplayed.Graph);
      }

      #endregion [Buttons Events Section]

      private void RefreshViewer(Graph graph)
      {
         SuspendLayout();
         m_gViewer.Graph = graph;
         ResumeLayout();
      }

      private void RefreshLoadedGraphsComboBox()
      {
         cbLoadedGraphs.DataSource = null;
         cbLoadedGraphs.DataSource = m_loadedGraphs;
      }

   }
}
