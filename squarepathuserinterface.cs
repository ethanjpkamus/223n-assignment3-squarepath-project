//Author: Ethan Kamus
//Email: ethanjpkamus@csu.fullerton.edu

//Purpose: to animate a circle moving along a rectangular path

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

      private enum current_direction{up,down,left,right};
      current_direction direction_indicator = current_direction.down;

      private enum current_color {red,gold};
      current_color color_indicator = current_color.red;

      //Timers

      /* The clock that refreshes the ui will only have one statement in
       * it the methods passed to the event handler which is Invalidate();
       */
      private static Systems.Timers.Timer ui_clock = new Systems.Timers.Timer();
      private static Systems.Timers.Timer circle_clock = new Systems.Timers.Timer();

      private Size maximum_window_size = new Size(1500,1000);
      private Size minimum_window_size = new Size(1500,1000);

      //brushes for OnPaint
      private SolidBrush redbrush = new SolidBrush(Color.Red);
      private SolidBrush goldbrush = new SolidBrush(Color.Gold);

      //constructor
      public squarepathuserinterface(){

            MaximimSize = maximum_window_size;
            MinimumSize = minimum_window_size;

            //Timer Intervals
            ui_clock.Interval = 33; //roughly 30 Hz
            ui_clock.Enabled = false;
            ui_clock.AutoReset = true;

            circle_clock.Interval = 17; //roughly 60 Hz
            circle_clock.Enabled = false;
            circle.clock.AutoReset = true;

            //Labels and Buttons
            Text = "Moving Ball Project by: Ethan Kamus";

            play_pause_button.Text = "Go!";
            reset_button.Text = "Reset";
            exit_button.Text = "Exit";

            //set sizes
            play_pause_button.Size = new Size(75,30);
            reset_button.Size = new Size(75,30);
            exit_button.Size = new Size(75,30);
            x_pos_label.Size = new Size(75,30);
            y_pos_label.Size = new Size(75,30);
            direction_label.Size = new Size(75,30);


            //set locations of buttons
            play_pause_button.Location = new Point(0,0);
            reset_button.Location = new Point(0,40);
            exit_button.Location = new Point(0,80);
            x_pos_label.Location = new Point(0,120);
            y_pos_label.Location = new Point(0,160);
            direction_label.Location = new Point(0,200);


            //add controls to the form
            Controls.Add(play_pause_button);
            Controls.Add(reset_button);
            Controls.Add(exit_button);
            Controls.Add(x_pos_label);
            Controls.Add(y_pos_label);
            Controls.Add(direction_label);

            //timer eventhandlers
            ui_clock.Elapsed += new ElapsedEventHandler(update_ui);
            circle_clock.Elapsed += new ElapsedEventHandler(update_circle_pos);

            //Button evenhandlers
            play_pause_button.Click += new EventHandler(update_play_pause);
            reset_button.Click += new EventHandler(update_reset);
            exit_button.Click += new EventHandler(update_exit);

      } //end of squarepathuserinterface constructor

      //methods
      protected override void OnPaint(PaintEventArgs e){

      } //end of OnPaint override

      protected void update_ui(Object o, ElapsedEventArgs e){

      } //end of update_ui

      protected void update_circle_pos(Object o, ElapsedEventArgs e){

      } //end of update_circle_pos

      protected void update_play_pause(Object o, EventArgs e){

      } //end of update_play_pause

      protected void update_reset(Object o, EventArgs e){

      } //end of update_reset

      protected void update_exit(Object o, EventArgs e){

      } //end of update_exit

} //end of squarepathuserinterface class bracket
