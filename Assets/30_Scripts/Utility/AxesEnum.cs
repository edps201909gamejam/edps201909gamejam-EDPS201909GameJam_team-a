using System.ComponentModel;

// by flanny7
// PS4のコントローラがjoystick 1
// PS2のコントローラがjoystick 2
// であることが前提です

public enum Axes
{
	[Description("p1_horizontal_button")]
	p1_horizontal_button,
	[Description("p1_vertical_button")]
	p1_vertical_button,
	[Description("p1_horizontal_stick_L")]
	p1_horizontal_stick_L,
	[Description("p1_vertical_stick_L")]
	p1_vertical_stick_L,
	[Description("p1_button_circle")]
	p1_button_circle,
	[Description("p1_button_cross")]
	p1_button_cross,
	[Description("p1_button_square")]
	p1_button_square,
	[Description("p1_button_triangle")]
	p1_button_triangle,
	[Description("p1_button_L1")]
	p1_button_L1,
	[Description("p1_button_L2")]
	p1_button_L2,
	[Description("p1_button_R1")]
	p1_button_R1,
	[Description("p1_button_R2")]
	p1_button_R2,
	[Description("p1_button_start")]
	p1_button_start,
	[Description("p1_button_select")]
	p1_button_select,
	[Description("p2_horizontal_button")]
	p2_horizontal_button,
	[Description("p2_vertical_button")]
	p2_vertical_button,
	[Description("p2_horizontal_stick_L")]
	p2_horizontal_stick_L,
	[Description("p2_vertical_stick_L")]
	p2_vertical_stick_L,
	[Description("p2_button_circle")]
	p2_button_circle,
	[Description("p2_button_cross")]
	p2_button_cross,
	[Description("p2_button_square")]
	p2_button_square,
	[Description("p2_button_triangle")]
	p2_button_triangle,
	[Description("p2_button_L1")]
	p2_button_L1,
	[Description("p2_button_L2")]
	p2_button_L2,
	[Description("p2_button_R1")]
	p2_button_R1,
	[Description("p2_button_R2")]
	p2_button_R2,
	[Description("p2_button_start")]
	p2_button_start,
	[Description("p2_button_select")]
	p2_button_select,
}

public enum AxesHorizontal
{
	[Description("p1_horizontal_button")]
	p1_horizontal_button,
	[Description("p1_horizontal_stick_L")]
	p1_horizontal_stick_L,
	[Description("p2_horizontal_button")]
	p2_horizontal_button,
	[Description("p2_horizontal_stick_L")]
	p2_horizontal_stick_L,
}

public enum AxesVertical
{
	[Description("p1_vertical_button")]
	p1_vertical_button,
	[Description("p1_vertical_stick_L")]
	p1_vertical_stick_L,
	[Description("p2_vertical_button")]
	p2_vertical_button,
	[Description("p2_vertical_stick_L")]
	p2_vertical_stick_L,
}