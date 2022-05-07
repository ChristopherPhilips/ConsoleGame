Public Interface ICharObjManager

    Sub onEnter(otherCharObj As CharObj) 'when i enter |check
    Sub onStand(otherCharObj As CharObj) 'when i end turn here
    Sub onLeave(otherCharObj As CharObj) 'when i leave |check


    Sub Entering(otherCharObj As CharObj) 'when someone else actually enters
    Sub Leaving(otherCharObj As CharObj) 'when someone else actually leaves


    Sub onAttemptedEnter(otherCharObj As CharObj) 'when somone else trys to enter my tile |check
    Sub onAttemptedStand(otherCharObj As CharObj) 'when someone else trys to ends turn on my tile (while being there last frame)
    Sub onAttemptedLeave(otherCharObj As CharObj) 'when someone else trys to leaves my tile |check


    Function doIcollide() As List(Of Char)    'who i collide with

End Interface
