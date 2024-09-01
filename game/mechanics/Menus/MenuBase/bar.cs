using System;
using Godot;

public static class AnimatedProgressBar 
{
    public static void Animate(ProgressBar progressBar, int value){
        var tween = progressBar.CreateTween();
        tween.TweenProperty(progressBar,"value",value,2).SetEase(Tween.EaseType.Out);
    }
}