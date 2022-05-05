Public Interface ICharObjManager

    Sub onEnter()

    Sub onStand()

    Sub onLeave()

    Function doIcollide() As List(Of Char)    'who i collide with

End Interface
