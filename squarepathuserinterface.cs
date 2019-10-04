//Author: Ethan Kamus
//Email: ethanjpkamus@csu.fullerton.edu

//Purpose: to animate a circle moving along a square path

using System;
using System.Drawing;
using System.Windows.Forms;
using Systems.Timers;

public class squarepathuserinterface : Form
{
       //items to be used in the user interface
       private Button play_pause_button = new Button();
       private Button reset_button = new Button();
       private Button exit_button = new Button();

       //labels for circle
       private Label x_pos_label = new Label();
       private Label y_pos_label = new Label();
       private Label direction_label = new Label();

       //circle properties
       private int x_pos = 0;
       private int y_pos = 0;
       private string direction = "DOWN";

       //Timers

       /* The clock that refreshes the ui will only have one statement in
        * it the methods passed to the event handler which is
        */
       private static Systems.Timers.Timer ui_clock = new Systems.Timers.Timer();
       private static Systems.Timers.Timer circle_clock = new Systems.Timers.Timer();

       //constructor

       //methods


}
