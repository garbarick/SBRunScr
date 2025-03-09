using SBRunScr.db;
using SBRunScr.form;
using SBRunScr.item;
using SBRunScr.resources;
using SBRunScr.user;
using SBRunScr.wall;

namespace SBRunScr.tray;

public class SBContext : ApplicationContext
{
    private static SBContext? current;
    public static SBContext? Current
    {
        get
        {
            return current;
        }
    }

    private readonly Settings settings = new();
    private readonly NotifyIcon trayIcon = new();
    private MainFrom? mainFrom;

    public ContextMenuStrip? Menu
    {
        get
        {
            return trayIcon.ContextMenuStrip;
        }
    }

    public SBContext()
    {
        current = this;
        trayIcon.Icon = Resources.GetIcon("main");
        trayIcon.Text = new User().AppName();
        trayIcon.Visible = true;
        trayIcon.DoubleClick += new EventHandler(Settings);
        InitItems();
    }

    private void InitItems()
    {
        ContextMenuStrip menu = trayIcon.ContextMenuStrip = new();
        menu.Items.Add(new ToolStripMenuItem("Settings", Resources.GetIconAsImage("settings"), Settings));
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add(new ToolStripMenuItem("Previous", Resources.GetIconAsImage("previous"), Previous));
        menu.Items.Add(new ToolStripMenuItem("Next", Resources.GetIconAsImage("next"), Next));
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add(new ToolStripMenuItem("Exit", Resources.GetIconAsImage("exit"), Exit));
    }

    private void Settings(object? sender, EventArgs e)
    {
        if (mainFrom == null || mainFrom.IsDisposed)
        {
            mainFrom = new MainFrom();
            mainFrom.Show();
        }
        else
        {
            mainFrom.WindowState = FormWindowState.Normal;
            mainFrom.Activate();
        }
    }

    private void Previous(object? sender, EventArgs args)
    {
        settings.SetPreviousFile();
        SetWallPaper();
        UpdateFilesList();
    }

    private void Next(object? sender, EventArgs args)
    {
        settings.SetNextFile();
        SetWallPaper();
        UpdateFilesList();
    }

    private void SetWallPaper()
    {
        FileItem? fileItem = settings.GetCurrentFile();
        if (fileItem != null)
        {
            new WallPaper().Set(fileItem.Path);
        }
    }

    private void UpdateFilesList()
    {
        if (mainFrom == null || mainFrom.IsDisposed)
        {
            return;
        }
        mainFrom.UpdateFilesList();
    }

    private void Exit(object? sender, EventArgs args)
    {
        trayIcon.Visible = false;
        Application.Exit();
    }
}