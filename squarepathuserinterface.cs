//Author: Ethan Kamus
//Email: ethanjpkamus@csu.fullerton.edu

//Purpose: to animate a circle moving along a rectangular path

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

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
      private int x_pos = 1400;
      private int y_pos = 300;

      //origin position
      private const int x_og = 1400;
      private const int y_og = 300;

      private enum current_direction{up,down,left,right,still};
      current_direction direction_indicator = current_direction.down;

      private enum current_color {red,gold};
      current_color color_indicator = current_color.red;

      //Timers

      /* The clock that refreshes the ui will only have one statement in
       * it the methods passed to the event handler which is Invalidate();
       */
      private static System.Timers.Timer ui_clock = new System.Timers.Timer();
      private static System.Timers.Timer circle_clock = new System.Timers.Timer();

      private Size maximum_window_size = new Size(1500,1000);
      private Size minimum_window_size = new Size(1500,1000);

      //brushes for OnPaint
      private SolidBrush redbrush = new SolidBrush(Color.Red);
      private SolidBrush goldbrush = new SolidBrush(Color.Gold);
      private Pen blackrectangle = new Pen(Color.Black);

      //constructor
      public squarepathuserinterface(){

            MaximumSize = maximum_window_size;
            MinimumSize = minimum_window_size;

            //Timer Intervals
            ui_clock.Interval = 33; //roughly 30 Hz
            ui_clock.Enabled = true;
            ui_clock.AutoReset = true;

            circle_clock.Interval = 33; //roughly 30 Hz
            circle_clock.Enabled = false;
            circle_clock.AutoReset = true;

            //Labels and Buttons
            Text = "Moving Ball Project by: Ethan Kamus";

            play_pause_button.Text = "Go!";
            reset_button.Text = "Reset";
            exit_button.Text = "Exit";
            direction_label.Text = "Direction: STILL";

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

            Graphics graph = e.Graphics;

            graph.DrawRectangle(blackrectangle,100,100,500,300);

            //determine the color of circle
            switch(color_indicator){

                  case current_color.red:
                        graph.FillEllipse(redbrush,x_pos,y_pos,50,50);
                        break;

                  case current_color.gold:
                        graph.FillEllipse(goldbrush,x_pos,y_pos,50,50);
                        break;
            }

            //update label for direction and positions
            x_pos_label.Text = x_pos.ToString();
            y_pos_label.Text = y_pos.ToString();

            base.OnPaint(e);

      } //end of OnPaint override

      protected void update_ui(Object o, ElapsedEventArgs e){

            Invalidate();

      } //end of update_ui

      protected void update_circle_pos(Object o, ElapsedEventArgs e){

            //calculate the movement of the circle based on its direction
            switch(direction_indicator){

                  case current_direction.down:

                        //update direction label
                        direction_label.Text = "Direction: DOWN";

                        //do math
                        y_pos += 2;

                        //check if circle reached the bottom of the rectangle
                        if(y_pos == 600){
                              direction_indicator = current_direction.left;
                        }
                        break;

                  case current_direction.left:

                        //update direction label
                        direction_label.Text = "Direction: LEFT";

                        //do math
                        x_pos -= 2;

                        //check if circle reached the left side of the rectangle
                        if(x_pos == 900){
                              direction_indicator = current_direction.up;
                        }

                        break;

                  case current_direction.up:

                        //update direction label
                        direction_label.Text = "Direction: UP";

                        //do math
                        y_pos -= 2;

                        //check if circle is at top of rectangle
                        if(y_pos == 300){
                              direction_indicator = current_direction.right;
                        }

                        break;

                  case current_direction.right:

                        //update direction label
                        direction_label.Text = "Direction: RIGHT";

                        //do math
                        x_pos += 2;

                        //check if circle is back at origin
                        if(x_pos == 1400){
                              direction_indicator = current_direction.still;
                        }


                        break;
                        
                  case current_direction.still:

                        direction_label.Text = "Direction: STILL";
                        circle_clock.Enabled = false;
                        color_indicator = current_color.gold;

                        play_pause_button.Text = "Go!";

                        break;
            } //end of switch statement

      } //end of update_circle_pos

      protected void update_play_pause(Object o, EventArgs e){

            bool opposite = !circle_clock.Enabled;
            circle_clock.Enabled = opposite;

            if(circle_clock.Enabled){
                  play_pause_button.Text = "Pause";
            }
            else {
                  play_pause_button.Text = "Play";
            }

      } //end of update_play_pause

      protected void update_reset(Object o, EventArgs e){

            circle_clock.Enabled = false;

            x_pos = x_og;
            y_pos = y_og;

      } //end of update_reset

      protected void update_exit(Object o, EventArgs e){

            Close();

      } //end of update_exit

} //end of squarepathuserinterface class bracket
