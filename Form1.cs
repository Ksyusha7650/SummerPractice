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
            drum,tape, disc, all = -1
        }
        List<Panel> panels = new List<Panel>();
        List<Button> buttons = new List<Button>();
        List<String> manifactures = new List<String>(), rawMat = new List<String>(), mat = new List<String>();
        string chosenManifactures, chosenRawMat, chosenMat, type;
        int minWeight = 25980, maxWeight = 25320, priceFromValue, priceToValue, amountOfChosenRawMaterial;
        int maxLength, minLength = 100500, maxWidth, minWidth = 100500, maxHeight, minHeight = 100500;

        private void minDiam_ValueChanged(object sender, EventArgs e)
        {
            minDiamDrum = Int32.Parse(minDiam.Value.ToString());
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
        }

        private void minLen_ValueChanged(object sender, EventArgs e)
        {
            maxLengthDrum = Int32.Parse(maxLen.Value.ToString());
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
        }

        private void maxLen_ValueChanged(object sender, EventArgs e)
        {
            minLengthDrum = Int32.Parse(minLen.Value.ToString());
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
        }

        private void minFreq_ValueChanged(object sender, EventArgs e)
        {
            minFrequencyDrum = float.Parse(minFreq.Value.ToString());
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
        }

        private void maxFreq_ValueChanged(object sender, EventArgs e)
        {
            maxFrequencyDrum = float.Parse(maxFreq.Value.ToString());
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
        }

        private void maxDiam_ValueChanged(object sender, EventArgs e)
        {
            maxDiamDrum = Int32.Parse(maxDiam.Value.ToString());
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
        }



        float maxPressure, minPressure = 1, maxPower, minPower = 25;
        int maxSquare, minSquare = 100500, maxWeightSingle, minWeightSingle = 100500;
        int minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum;
        float minFrequencyDrum, maxFrequencyDrum;
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
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
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
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
        }

        private void priceTo_ValueChanged(object sender, EventArgs e)
        {
            priceToValue = Int32.Parse(priceTo.Value.ToString());
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
        }

        private void priceFrom_ValueChanged(object sender, EventArgs e)
        {
            priceFromValue = Int32.Parse(priceFrom.Value.ToString());
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
        }

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
            buttons.Add(buttonDiscFilter);
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
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
            tableFilters.Columns[0].Frozen = true;
            minDiamDrum = Int32.Parse(minDiam.Value.ToString());
            maxDiamDrum = Int32.Parse(maxDiam.Value.ToString());
            minLengthDrum = Int32.Parse(minLen.Value.ToString());
            maxLengthDrum = Int32.Parse(maxLen.Value.ToString());
            minFrequencyDrum = float.Parse(minFreq.Value.ToString());
            maxFrequencyDrum = float.Parse(maxFreq.Value.ToString());
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
        //    type = ((Button)sender).Tag.ToString();
            filters fil = (filters)index;
            type = fil.ToString();
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            HidePanels();
            panelButtons.Visible = true;
            chosenManifactures = chosenRawMat = chosenMat = type = "all";
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
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
            tableFilters.DataSource = DataBase.GetFilters2(type, chosenManifactures, minWeight, maxWeight
                , chosenRawMat, amountOfChosenRawMaterial, minLength, maxLength, minWidth, maxWidth, minHeight, maxHeight, minPressure,
                maxPressure, minPower, maxPower, minSquare, maxSquare, minWeightSingle, maxWeightSingle,
                chosenMat, priceToValue, priceFromValue, minLengthDrum, maxLengthDrum, minDiamDrum, maxDiamDrum,
                minFrequencyDrum, maxFrequencyDrum);
        }
    }
}
