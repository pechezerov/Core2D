﻿#nullable enable
using System;

namespace Core2D.ViewModels.Editor.History;

public readonly partial struct UndoRedo
{
    public readonly Action Undo;

    public readonly Action Redo;

    public UndoRedo(Action undo, Action redo)
    {
        Undo = undo;
        Redo = redo;
    }

    public static UndoRedo Create(Action undo, Action redo)
    {
        return new UndoRedo(undo, redo);
    }
}