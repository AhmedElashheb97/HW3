using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherAttendance.helper;
using TeacherAttendance.model;

namespace TeacherAttendance
{
    public partial class frmTeacherAttendance : Form
    {
        private List<Attendance> attendancelist = new List<Attendance>();
     
        private AttendanceManagement attendance;
        public frmTeacherAttendance()
        {
            InitializeComponent();
        }

        private void FrmTeacherAttendance_Load(object sender, EventArgs e)
        {
           attendance = new AttendanceManagement();
            ShowCourses();
            ShowTeachers();
            ShowRooms();

            button2.Enabled = false;
        }

        /*private void CmbCourses_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }*/

        private void ShowCourses()
        {
            cmbCourses.DataSource = null;
            cmbCourses.DisplayMember = "CourseName";
            cmbCourses.ValueMember = "CourseId";
            cmbCourses.DataSource = attendance.getAllCourses();
            cmbCourses.SelectedIndex = -1;
        }

        private void ShowTeachers()
        {
            cmbTeacherName.DataSource = null;
            cmbTeacherName.DisplayMember = "TeacherName";
            cmbTeacherName.ValueMember = "TeacherId";
            cmbTeacherName.DataSource = attendance.getAllTeachers();
            cmbTeacherName.SelectedIndex = -1;

        }

        private void ShowRooms()
        {
            cmbRoom.DataSource = null;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomId";
            cmbRoom.DataSource = attendance.getAllRooms();
            cmbRoom.SelectedIndex = -1;

        }
        private void CmbCourses_SelectionChangeCommitted(object sender, EventArgs e)
        {


            string value = "";


            int id = ((Course)((ComboBox)sender).SelectedItem).CourseId;

            if (id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New course", "New course name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewCourse(value.Trim());
                    ShowCourses();
                }


            }
        }

        private void CmbTeacherName_SelectionChangeCommitted(object sender, EventArgs e)
        {


            string value = "";


            int id = ((Teacher)((ComboBox)sender).SelectedItem).TeacherId;

            if (id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New teacher", "New teacher name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewTeacher(value.Trim());
                    ShowTeachers();
                }


            }


        }

        private void CmbRoom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string value = "";


            int id = ((Room)((ComboBox)sender).SelectedItem).RoomId;

            if (id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New Room/Lab", "New Room/Lab name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewRoom(value.Trim());
                    ShowRooms();
                }


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           /* attendancelist.Add(new Attendance(cmbTeacherName, cmbCourses.SelectedText, cmbRoom.SelectedText,
                dateTimePicker2.Text, dateTimePicker3.Text, textBox2.Text));*/

           Object selected = this.cmbTeacherName.GetItemText(this.cmbTeacherName.SelectedItem);
            Object sel2 = this.cmbRoom.GetItemText(this.cmbRoom.SelectedItem);
          Object sel3 = this.cmbCourses.GetItemText(this.cmbCourses.SelectedItem);
            attendancelist.Add(new Attendance(selected, sel3, sel2,
                       dateTimePicker2.Text, dateTimePicker3.Text, textBox2.Text));

          
            dataGridView1.DataSource = attendancelist.ToList();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("hi");


            cmbCourses.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cmbTeacherName.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmbRoom.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            DateTime date = new DateTime();
            string date_str = date.ToString(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            dateTimePicker2.Text = date_str;
            string date_str1 = date.ToString(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            dateTimePicker3.Text = date_str1;

            btnSave.Enabled = false;
            button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Object selected = this.cmbTeacherName.GetItemText(this.cmbTeacherName.SelectedItem);
            Object sel2 = this.cmbRoom.GetItemText(this.cmbRoom.SelectedItem);
            Object sel3 = this.cmbCourses.GetItemText(this.cmbCourses.SelectedItem);
            attendancelist.Add(new Attendance(selected, sel3, sel2,
                       dateTimePicker2.Text, dateTimePicker3.Text, textBox2.Text));
            dataGridView1.CurrentRow.Cells[0].Value = cmbTeacherName.Text;
            dataGridView1.CurrentRow.Cells[1].Value = cmbCourses.Text;
            dataGridView1.CurrentRow.Cells[2].Value = cmbRoom.Text;
            dataGridView1.CurrentRow.Cells[3].Value = dateTimePicker2.Text;
            dataGridView1.CurrentRow.Cells[4].Value = dateTimePicker3.Text;
            dataGridView1.CurrentRow.Cells[5].Value = textBox2.Text;

            btnSave.Enabled = true;
            button2.Enabled = false;
           
        }

      /*  private void cmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }*/
        
    }
}

        

     

