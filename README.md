# MVVM With SingeleTonSean

## Disclaimer
I'm learning MVVM pattern and i started this repo as exercising coding along with <a href="https://www.youtube.com/playlist?list=PLA8ZIAm2I03hS41Fy4vFpRw8AdYNBXmNm">SingeleToneSean's Playlist about MVVM </a>


<div align="center">
<h5>Preview of the app</h5>
<img src="https://github.com/itayG98/MVVMSingeleTonSean/blob/618f398f1363dbdc35521a49b9e61c5b17c9e095/MVVM/PreView/FirtPreviw.jpg" width="800">
</div>

## Purpose
The app should simply allow a costumer to reserve a room in fictional hotel inserting 5 inputs

1. UserName
2. FloorNum
3. RoomNum
4. Date of start 
5. Date of end 

It should show list of all the reservation validate new ones and update SQL local Server .

## Validation 
All this property binded to the MakeReservationViewModel properties here is an exmple : 
https://github.com/itayG98/MVVM-Hotel-Reservation-WPF/blob/3efa25d8dbb311a197bb4dc3ad22b7348d19d053/View/Views/MakeReservationView.xaml#L52-L55

Using Commands I enable and disable the button of submiting checking if there is username room number and floor num 
if so calls the OnCanExecute() that invokes the boolian method :
https://github.com/itayG98/MVVM-Hotel-Reservation-WPF/blob/3efa25d8dbb311a197bb4dc3ad22b7348d19d053/ViewModel/Commands/MakeReservationCommand.cs#L66-L72

Whent CanExecute is true the submit calls async method that uses validator objects to check if there is error in the data or conflict with reservation from the data base 
The validator named DatabaseReservationConflictValidator  and implementing IReservationConflicValidator so the app is open for new Validetor addition in the future

https://github.com/itayG98/MVVM-Hotel-Reservation-WPF/blob/3efa25d8dbb311a197bb4dc3ad22b7348d19d053/Model/Services/ReservationConflictValidator/DatabaseReservationConflictValidator.cs#L19-L32
