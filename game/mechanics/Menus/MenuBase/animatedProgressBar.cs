using System;
using System.Threading.Tasks;
using Godot;
using PorygonC.Scenes.Domain;

public static class AnimatedProgressBar 
{
    public static async Task Animate(ProgressBar progressBar, int value){
        var tween = progressBar.CreateTween();
        var time = Math.Min(2,Math.Abs(progressBar.Value - value*0.1));
        tween.TweenProperty(progressBar,"value",value,time).SetEase(Tween.EaseType.Out);
        await Task.Delay((int)(time*1000) + 500);
    }
}