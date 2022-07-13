using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummerPractice
{
    public partial class Form1 : Form
    {
        enum filters
        {
            drum,tape, disk, all = -1
        }
        List<Panel> panels = new List<Panel>();
        List<Button> buttons = new List<Button>();
        List<String> manifactures = new List<String>(), rawMat = new List<String>(), mat = new List<String>();
        string chosenManifactures, chosenRawMat, chosenMat, type;
        int minWeight = 25980, maxWeight = 25320, priceFromValue, priceToValue, amountOfChosenRawMaterial;
        int maxLength, minLength = 100500, maxWidth, minWidth = 100500, maxHeight, minHeight = 100500;
        float maxPressure, minPressure = 1, maxPower, minPower = 25;
        int maxSquare, minSquare = 100500, maxWeightSingle, minWeightSingle = 100500;
        int minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum;
        float minFrequencyDrum, maxFrequencyDrum;
        float minDiamDisk = 0, maxDiamDisk = 3; int amountSectorsDiskMin = 0, amountSectorsDiskMax = 20;
        int widthTapeMin = 0, widthTapeMax = 2000; float speedTapeMin = 0, speedTapeMax = 1;

        public Form1()
        {
            InitializeComponent();
            type = "all";
            panels.Add(drumFilter);
            panels.Add(panelTape);
            panels.Add(panelDisc);
            panels.Add(panelButtons);
            buttons.Add(buttonDrumFilter);
            buttons.Add(buttonTapeFilter);
            buttons.Add(buttonDiskFilter);
            manifactures = DataBase.GetManifactures();
            foreach (String manifacture in manifactures)
            {
                checkedListBoxManifactures.Items.Add(manifacture);
            }
            rawMat = DataBase.GetRawMaterial(type);
            foreach (String raw in rawMat)
            {
                checkedListBoxRawMaterials.Items.Add(raw);
            }
            mat = DataBase.GetMaterials();
            foreach (String m in mat)
            {
                checkedListBoxMaterials.Items.Add(m);
            }
            chosenManifactures = chosenRawMat = chosenMat = type = "all";
            priceFromValue = Int32.Parse(priceFrom.Value.ToString());
            priceToValue = Int32.Parse(priceTo.Value.ToString());
            tableFilters.DataSource = DataBase.GetFilters(type, chosenManifactures, minWeight, maxWeight
               , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
               maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
               chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
               minFrequencyDrum, maxFrequencyDrum, widthTapeMin, widthTapeMax, speedTapeMin, speedTapeMax,
               minDiamDisk, maxDiamDisk, amountSectorsDiskMin, amountSectorsDiskMax);
            tableFilters.Columns[0].Frozen = true;
            minDiamDrum = Int32.Parse(minDiam.Value.ToString());
            maxDiamDrum = Int32.Parse(maxDiam.Value.ToString());
            minLengthDrum = Int32.Parse(minLen.Value.ToString());
            maxLengthDrum = Int32.Parse(maxLen.Value.ToString());
            minFrequencyDrum = float.Parse(minFreq.Value.ToString());
            maxFrequencyDrum = float.Parse(maxFreq.Value.ToString());
        }

        private void object_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown obj = (NumericUpDown)sender;
            string fieldTextNumeric = obj.Tag.ToString();
            switch (fieldTextNumeric)
            {
                case "priceMin":
                    priceFromValue = Int32.Parse(obj.Value.ToString());
                    break;
                case "priceMax":
                    priceToValue = Int32.Parse(obj.Value.ToString());
                    break;
                case "diamDiskMin":
                    minDiamDisk = float.Parse(obj.Value.ToString());
                    break;
                case "diamDiskMax":
                    maxDiamDisk = float.Parse(obj.Value.ToString());
                    break;
                case "amountSectorsDiskMin":
                    amountSectorsDiskMin = Int32.Parse(obj.Value.ToString());
                    break;
                case "amountSectorsDiskMax":
                    amountSectorsDiskMax = Int32.Parse(obj.Value.ToString());
                    break;
                case "widthTapeMin":
                    widthTapeMin = Int32.Parse(obj.Value.ToString());
                    break;
                case "widthTapeMax":
                    widthTapeMax = Int32.Parse(obj.Value.ToString());
                    break;
                case "speedTapeMin":
                    speedTapeMin = float.Parse(obj.Value.ToString());
                    break;
                case "speedTapeMax":
                    speedTapeMax = float.Parse(obj.Value.ToString());
                    break;
                case "minDiam":
                    minDiamDrum = Int32.Parse(obj.Value.ToString());
                    break;
                case "maxDiam":
                    maxDiamDrum = Int32.Parse(obj.Value.ToString());
                    break;
                case "minLen":
                    minLengthDrum = Int32.Parse(obj.Value.ToString());
                    break;
                case "maxLen":
                    maxLengthDrum = Int32.Parse(obj.Value.ToString());
                    break;
                case "minFreq":
                    minFrequencyDrum = float.Parse(obj.Value.ToString());
                    break;
                case "maxFreq":
                    maxFrequencyDrum = float.Parse(obj.Value.ToString());
                    break;
            }
            tableFilters.DataSource = DataBase.GetFilters(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum, widthTapeMin, widthTapeMax, speedTapeMin, speedTapeMax,
                minDiamDisk, maxDiamDisk, amountSectorsDiskMin, amountSectorsDiskMax);
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            string type_sort = ((Button)sender).Tag.ToString();
            int amountCol = tableFilters.ColumnCount - 1;
            switch (type_sort)
            {
                case "default":
                    {
                        tableFilters.Sort(tableFilters.Columns[0], ListSortDirection.Ascending);
                        break;
                    }
                case "alphabet":
                    {
                        tableFilters.Sort(tableFilters.Columns[0], ListSortDirection.Ascending);
                        break;
                    }
                case "price_up":
                    {
                      
                        tableFilters.Sort(tableFilters.Columns[amountCol], ListSortDirection.Ascending);
                        break;
                    }
                case "price_down":
                    {
                        tableFilters.Sort(tableFilters.Columns[amountCol], ListSortDirection.Descending);
                        break;
                    }
            }
        }

        private void checkedListBoxRawMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            chosenRawMat = "";
            amountOfChosenRawMaterial = 0;
            foreach (string s in checkedListBoxRawMaterials.CheckedItems)
            {
                chosenRawMat += s + ",";
                amountOfChosenRawMaterial++;
            }
            if (chosenRawMat.Length > 0)
                chosenRawMat = chosenRawMat.Remove(chosenRawMat.Length - 1);
            else chosenRawMat = "all";
            tableFilters.DataSource = DataBase.GetFilters(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum, widthTapeMin, widthTapeMax, speedTapeMin, speedTapeMax,
                minDiamDisk, maxDiamDisk, amountSectorsDiskMin, amountSectorsDiskMax);
        }

        private void checkedListBoxMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            chosenMat = "";
            foreach (string s in checkedListBoxMaterials.CheckedItems)
            {
                chosenMat += s + ",";
            }
            if (chosenMat.Length > 0)
                chosenMat = chosenMat.Remove(chosenMat.Length - 1);
            else chosenMat = "all";
            tableFilters.DataSource = DataBase.GetFilters(type, chosenManifactures, minWeight, maxWeight
                 , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                 maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                 chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                 minFrequencyDrum, maxFrequencyDrum, widthTapeMin, widthTapeMax, speedTapeMin, speedTapeMax,
                 minDiamDisk, maxDiamDisk, amountSectorsDiskMin, amountSectorsDiskMax);
        }

        private void HidePanels()
        {
            foreach (Panel panel in panels)
            {
                panel.Visible = false;
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            HidePanels();
            int index = Int32.Parse(((Button)sender).Tag.ToString());
            panels[index].Visible = true;
            filters fil = (filters)index;
            type = fil.ToString();
            tableFilters.DataSource = DataBase.GetFilters(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum, widthTapeMin, widthTapeMax, speedTapeMin, speedTapeMax,
                minDiamDisk, maxDiamDisk, amountSectorsDiskMin, amountSectorsDiskMax);

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            HidePanels();
            panelButtons.Visible = true;
            chosenManifactures = chosenRawMat = chosenMat = type = "all";
            tableFilters.DataSource = DataBase.GetFilters(type, chosenManifactures, minWeight, maxWeight
                         , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                         maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                         chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                         minFrequencyDrum, maxFrequencyDrum, widthTapeMin, widthTapeMax, speedTapeMin, speedTapeMax,
                         minDiamDisk, maxDiamDisk, amountSectorsDiskMin, amountSectorsDiskMax);
            for (int i = 0; i < checkedListBoxManifactures.Items.Count; i++)
                checkedListBoxManifactures.SetItemCheckState(i, CheckState.Unchecked);
            for (int i = 0; i < checkedListBoxMaterials.Items.Count; i++)
                checkedListBoxMaterials.SetItemCheckState(i, CheckState.Unchecked);
            for (int i = 0; i < checkedListBoxRawMaterials.Items.Count; i++)
                checkedListBoxRawMaterials.SetItemCheckState(i, CheckState.Unchecked);
            
        }

        private void checkedListBoxManifactures_SelectedIndexChanged(object sender, EventArgs e)
        {
            chosenManifactures = "";
            foreach(string s in checkedListBoxManifactures.CheckedItems)
            {
                chosenManifactures +=  s + ",";
            }
            if (chosenManifactures.Length > 0)
                chosenManifactures = chosenManifactures.Remove(chosenManifactures.Length - 1);
            else chosenManifactures = "all";
            tableFilters.DataSource = DataBase.GetFilters(type, chosenManifactures, minWeight, maxWeight
                          , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                          maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                          chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                          minFrequencyDrum, maxFrequencyDrum, widthTapeMin, widthTapeMax, speedTapeMin, speedTapeMax,
                          minDiamDisk, maxDiamDisk, amountSectorsDiskMin, amountSectorsDiskMax);
        }
    }
}
