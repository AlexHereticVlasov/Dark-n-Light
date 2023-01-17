public sealed class VoidBridge : MagicBridge
{
    public override void Activate()
    {
        base.Activate();
        StartCoroutine(DeactivateRoutine());
    }

    public override void Deactivate()
    {
        base.Deactivate();
        StartCoroutine(ActivateRoutine());
    }
}

/*
Forgotten... 
Disunited... 
Weak... 
We have waited so long for the cold heavens to finally give us a sign. 
And at last the stars flashed brighter...
The serpent once again clutched at its own tail... and the circle closed!
Now the time of the Ancients is over... 
In the dark corners of the Earth... 
Beneath the eternal rocks... 
In the depths of the ancient seas...
Buried alive in forgotten crypts our brothers still languish... 
Can you feel it? The power fills you again!
Wake up!
Our time has come, 
go and break the seals, black as the souls of our enemies. 
Bring freedom to those who have remained loyal to me...
And bring death to all who dare stand in your way.
 */
