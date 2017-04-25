# GbSchedule
GbSchedule.NET allow you to schedule any number of categories, providers, rooms, and appointments. This is an older commercial product that has been released as open source. It a .NET Windows control for scheduling applications. It was in production until 2008 but it still functions quite well. You can use it to develop a WinForms app with great scheduling ability. Also sorry but it is written in VB.NET. :angry:

**Normal View**

![Schedule Example](https://github.com/gravbox/GbSchedule/blob/master/Docs/Schedule1.png?raw=true)

**Transparent with rounded corners**

![Schedule Example](https://github.com/gravbox/GbSchedule/blob/master/Docs/Schedule2.png?raw=true)

Gravitybox Schedule.NET is a great Scheduling component. You may run any type of business that requires complex scheduling with it. It plugs into any Visual Studio.NET language to enhance your applications with advanced drag-and-drop scheduling capabilities. It works right out of the box to provide a sophisticated, visual appointment catalog. 

GbSchedule.NET allow you to schedule any number of categories, providers, rooms, and appointments. Of course appointments are the centerpiece of the component and may be configured in a myriad of ways to display virtually any type of information to your users. Each application has its own unique needs for information display. GbSchedule.NET allows you to exhibit your information in numerous modes that are defined by the presentation of information such as date, time, room, provider, or category. These modes allow you to show combination of these attributes on the horizontal or vertical axis: Dates-Top/Time-Left, Rooms-Top/Time-Left, or Providers-Top/Time-Left. You may flip-flop this design and put times on the horizontal axis if desired. There is also a month mode to display appointments for a month at a time. View modes allow the GbSchedule.NET component to be very useful for doctor office applications. It was designed from the ground up with office scheduling in mind!

Conflicts are perhaps the most difficult issue to handle when scheduling. GbSchedule.NET has a very sophisticated conflict resolution built-in. Conflict resolution is integrated into the product. There is no need to build your own algorithms. You may check an existing appointment or a proposed space for conflicts. Conflicts may also be displayed in three ways: overlap, side-by-side, or stagger.

Each appointment may be configured to have a customized appearance. An appointment may (or may not) have a header. The header has a back color, text color, font setting, icon, transparency setting, and separator. Each appointment body has a back color, text color, font setting, icon, transparency setting, and any number of user-defined icons. In addition appointment may be rectangular or rounded.

#### Features
TimeIncrement Set the display of the schedule to any factor of 60.

#### Events
There are numerous "BeforeXXX" and "AfterXXX" events. These allow you to know when an action is pending and when that action is complete. For example the BeforeAppointmentRemove and AfterAppointmentRemove.

#### Colors and Transparency
The colors of the header and grid are configurable as well as those for each appointment. Appointments also may be partially transparent.

#### Dialogs
There are numerous build-in dialog screens. The most commonly used is the appointment property dialog. Also there are configuration dialogs for the various collections for rooms, categories, and providers. There allow you to have an easy to use configuration screen if you do not wish to build your own.

#### NoDropAreas
Define areas that do not allow appointments. A NoDropArea will not allow the user to create or edit appointments in their defined area. 
Import/Export Appointments may be exported to/from XML files or the international standard vCalendar format. This allows you to export your data to MS-Outlook of other vCalendar applications.

#### Viewmode
This property allows you to display your appointment data in a multitude of ways.

#### ScheduleProperties
This component may be used to allow appointment edits. The default appointment property dialog wraps this component and it fine for most developers. However this component is exposed as public for those who wish to build their own edit screen.

#### Recurrent Appointments
Appointments may be used to create a recurrence pattern. This pattern will create a number of appointments that match the pattern. An example is an appointment that occurs each Monday for 3 months.

#### Multi-day Appointments
You may now create appointments that cross day boundaries. They may start on one day and stretch for any number of days.

#### Appointment Icons
Each appointment has a collection of icons. You may add graphics to this collection and each will be displayed on the left margin of the appointment.

#### The "Apple" look-and-feel
Each appointment may be configured in many different ways. A stylish look is the one presented by the iCal application. Appointments are round with a header and transparent background.

#### Appointment Events
Each appointment has numerous events. Events are raised some time before an appointment as a reminder. Also one is raised at an appointment's start. Also applications may be executed when an appointment is due. There is also a built-in alarm dialog that looks like the one presented by MS-Outlook.

#### Owner-drawn
Some UI elements may be owner-drawn. This allows you to draw your own non-standard graphics on the schedule. This allows you to show non-standard graphic displays.

#### Print/Preview
The schedule has built-in functionality for printing and previewing of the schedule graphic.
