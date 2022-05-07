Public Interface ICharObjManager

    Sub onEnter(otherCharObjType As Char) 'when i enter

    Sub onStand(otherCharObjType As Char) 'when i end turn here

    Sub onLeave(otherCharObjType As Char) 'when i leave

    Sub onAttemptedEnter(otherCharObjType As Char) 'when somone else trys to enter my tile

    Sub onAttemptedStand(otherCharObjType As Char) 'when someone else ends turn on my tile

    Sub onAttemptedLeave(otherCharObjType As Char) 'when someone else leaves my tile

    Function doIcollide() As List(Of Char)    'who i collide with

End Interface
