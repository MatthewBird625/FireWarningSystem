var map;

async function InitMap(subscriptionKey) {
    /*    clear any existing map to avoid duplicate map layers*/
    //let parentElement = document.getElementById('azureMap');
    //parentElement.innerHTML = "";
    if (map != null) {
        map.clear();
    }

    return new Promise((resolve, reject) => {
        map = new atlas.Map('azureMap', {
            center: [144.962646, -37.810272],
            zoom: 12,
            duration: 1000,
            type: 'fly',
            language: 'en-US',
            authOptions: {
                authType: 'subscriptionKey',
                subscriptionKey: subscriptionKey
            }
        });

        map.events.add('ready', function () {

            map.controls.add([
                new atlas.control.ZoomControl(),
                new atlas.control.CompassControl(),
                new atlas.control.PitchControl(),
                new atlas.control.StyleControl()
            ], {
                position: "top-left"
            });

            resolve();
        });

        map.events.add('error', function (e) {
            reject(e); 
        });
    });
}

async function GenerateStatusMap(subscriptionKey, activities, actIncidents, cfaIncidents, nswIncidents, ntIncidents, qldIncidents, saIncidents, tasIncidents, waIncidents) {
    try {
        await InitMap(subscriptionKey); 
        AddWarningSetToMap(actIncidents);
        AddWarningSetToMap(cfaIncidents);
        AddWarningSetToMap(nswIncidents);
        AddWarningSetToMap(ntIncidents);
        AddWarningSetToMap(qldIncidents);
        AddWarningSetToMap(saIncidents);
        AddWarningSetToMap(tasIncidents);
        AddWarningSetToMap(waIncidents);

    } catch (error) {
        console.error('Error initializing the map:', error);
    }
}

async function AddWarningSetToMap(incidents) {
    var WarningTemplate =
        `<div style="padding:10px">
                    <div><table><td>Title:</td><td>{title}</td></tr>{description}</table></div></div>`;

    var dataSource = new atlas.source.DataSource();
    map.sources.add(dataSource);

    incidents.forEach(warning => {
        try {
            dataSource.add(new atlas.data.Feature(new atlas.data.Point([warning.longitude, warning.latitude]), {
                type: warning.stateType,
                title: warning.title,
                description: warning.description
            }));
        }
        catch (e) {
            //TODO - set dotnet helper and callback to dotnet and display snackbar error message 
        }
    });

    var iconText = "";
    if (incidents[0] != null) {
        iconText = incidents[0].stateType;
    }

    var symbolLayer = new atlas.layer.SymbolLayer(dataSource, null, {
        iconOptions: {
            image: 'marker-red',

            size: 1
        },

        textOptions: {
            textField: iconText,
            size: 12,
            offset: [0, -1.5]
        }
    });

    map.layers.add(symbolLayer);

    popup = new atlas.Popup({
        pixelOffset: [0, -18],
        closeButton: false
    });

    map.events.add('mouseenter', symbolLayer, function (e) {
        console.log("mouse enter");
        if (e.shapes && e.shapes.length > 0) {
            var content, coordinate;
            var properties = e.shapes[0].getProperties();

            content = WarningTemplate.replace(/{title}/g, properties.title)
                .replace(/{description}/g, properties.description);

            coordinate = e.shapes[0].getCoordinates();

            popup.setOptions({
                content: content,
                position: coordinate

            });
            popup.open(map);
        }
    });

    map.events.add('mouseleave', symbolLayer, function () {
        console.log("mouse leave");
        popup.close();
    });
}