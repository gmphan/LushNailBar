// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//document.ready was called from sample-sources js file
//so I don't need to do it again
//with out if statement, a page without service-type-list id 
//will give error, and this site.js will not work
let serviceTypeListElement = document.getElementById("service-type-list");
if(serviceTypeListElement !== null){
    let currentActiveHref = "";

    //need to get the price-list-service table id which is displaying
    //The hrefs were created by add '#' with service-type key
    for(let i = 0; i < serviceTypeListElement.childElementCount; i++){
        if(serviceTypeListElement.children[i].className == "active"){
            currentActiveHref = serviceTypeListElement.children[i].children[0].attributes.href.value
        }
    }

    // table Ids are the service-type keys
    let activeTableId = currentActiveHref.replace('#', '');

    $('.service-link').on("click", function(){
        
        /**
         * For service-type-list nav
         * **/
        
        //1st remove active status from the current active li
        removeActiveStatus();

        //2nd get the href link after click
        let hrefLink = getClickedHrefLink(this);
        console.log("clicked href", hrefLink)

        //3rd get the li index from the clicked a inside of it
        let ActiveLiIndex = getIndexOfClickedLi(hrefLink);

        //4th add the active class to the li
        addActiveStatus(ActiveLiIndex);

        /**
         * Show and hide price-list-service table
         */
        
        let newActiveTableId = hrefLink.replace("#", '');
        hideAndDisplayTable(activeTableId, newActiveTableId);

        //need to replace the activeTableId with newActiveTableId
        activeTableId = newActiveTableId;


    })
}



//remove active class 
function removeActiveStatus(){    
    for(let i = 0; i < serviceTypeListElement.childElementCount; i++){
        if(serviceTypeListElement.children[i].className === "active"){
            serviceTypeListElement.children[i].classList.remove("active");
        }
    }
    return true;
}

function getClickedHrefLink(onclickValues){
    const $thisHref = $(onclickValues).attr("href");
    var poundPosition = $thisHref.search('#');
    const hrefString = $thisHref.substring(poundPosition, poundPosition.length);
    return hrefString;
}

function getIndexOfClickedLi(hrefLink){
    //loop through children of the ul to get the href which match with the clicked one
    for(let i = 0; i < serviceTypeListElement.childElementCount; i++){
        for(let k = 0; k < serviceTypeListElement.children[i].childElementCount; k++){
            let hrefValue = serviceTypeListElement.children[i].children[0].attributes.href.value;
            if(hrefLink == hrefValue){
                console.log("matching", hrefValue)
                console.log(i)
                return i
            }
        }
    }
}

function addActiveStatus(index){
    serviceTypeListElement.children[index].classList.add("active");
    return true;
}

function hideAndDisplayTable(oldId, newId){
    document.getElementById(oldId).classList.add('hidden')
    document.getElementById(newId).classList.remove('hidden')
}


// this for ServiceType selection option
function createNewType(selectedValue){
    if(selectedValue == "add-new"){
        document.getElementById("serviceTypeDivChild2").classList.remove("hidden")

        //razor posts value by name, so removing name attribute > razor will use
        //the input of the add new box
        document.getElementById("serviceTypeSelection").removeAttribute("name");

        //make sure to check all to see if the enter value match one of the existing
        // case not sensitive 
        // if match > alert popup > won't submit

        
    } 
    else{
        document.getElementById("serviceTypeDivChild2").classList.add("hidden")
    }
}
