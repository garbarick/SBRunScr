using System.Drawing.Printing;
using SBRunScr.resources;

namespace SBRunScr.view.settings.files;

partial class FilesPanel
{
    private ListView Lists;
    private ListView Files;
    private PictureBox Image;
    private Panel FilesButtons;

    private void InitializeComponent()
    {
        Text = "Files";
        Dock = DockStyle.Fill;

        Lists = CreateListsView();
        Files = CreateFilesView();
        Image = CreateImageView();

        Controls.Add(CreateMainPanel());
    }

    private ListView CreateListsView()
    {
        ListView result = new();
        result.Dock = DockStyle.Fill;
        result.View = View.Details;
        result.FullRowSelect = true;
        result.GridLines = true;
        result.SelectedIndexChanged += new EventHandler(ListsSelectedChanged);

        result.Columns.Add("List", 140);
        result.Columns.Add("Count", 80);

        return result;
    }

    private ListView CreateFilesView()
    {
        ListView result = new();
        result.Dock = DockStyle.Fill;
        result.View = View.Details;
        result.FullRowSelect = true;
        result.GridLines = true;

        result.Columns.Add("Path", 340);
        result.Columns.Add("Type", 80);
        result.Columns.Add("Name", 100);

        return result;
    }

    private PictureBox CreateImageView()
    {
        PictureBox result = new();
        result.Dock = DockStyle.Fill;
        result.BorderStyle = BorderStyle.FixedSingle;
        return result;
    }

    private Control CreateListLayout()
    {
        TableLayoutPanel result = new();
        result.Dock = DockStyle.Fill;
        result.ColumnCount = 3;
        result.RowCount = 1;
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));
        result.Controls.Add(CreateListsButtons());
        result.Controls.Add(Lists);
        result.Controls.Add(Image);
        return result;
    }

    private Control CreateListsButtons()
    {
        Panel result = new();
        result.Dock = DockStyle.Fill;
        result.Controls.Add(CreateButton("deleteList", new EventHandler(DeleteList)));
        result.Controls.Add(CreateButton("editList", new EventHandler(EditList)));
        result.Controls.Add(CreateButton("addList", new EventHandler(AddList)));
        return result;
    }

    private Control CreateButton(string name, EventHandler handler)
    {
        Button result = new();
        result.Image = Resources.GetIconAsImage(name);
        result.Size = new Size(0, 40);
        result.Dock = DockStyle.Top;
        result.Click += handler;
        return result;
    }

    private Control CreateFilesLayout()
    {
        TableLayoutPanel result = new();
        result.Dock = DockStyle.Fill;
        result.ColumnCount = 2;
        result.RowCount = 1;
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        result.Controls.Add(FilesButtons = CreateFilesButtons());
        result.Controls.Add(Files);
        return result;
    }

    private Panel CreateFilesButtons()
    {
        Panel result = new();
        result.Dock = DockStyle.Fill;
        result.Controls.Add(CreateButton("clearFiles", new EventHandler(ClearFiles)));
        result.Controls.Add(CreateButton("excludeFolder", new EventHandler(ExcludeFolder)));
        result.Controls.Add(CreateButton("addFolder", new EventHandler(AddFolder)));
        return result;
    }

    private Control CreateMainPanel()
    {
        TableLayoutPanel result = new();
        result.Dock = DockStyle.Fill;
        result.ColumnCount = 1;
        result.RowCount = 2;
        result.RowStyles.Add(new RowStyle(SizeType.Absolute, 200));
        result.Controls.Add(CreateListLayout());
        result.Controls.Add(CreateFilesLayout());
        return result;
    }
}