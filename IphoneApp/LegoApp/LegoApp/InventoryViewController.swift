//
//  InventoryViewController.swift
//  LegoApp
//
//  Created by Helena Tamburić on 31/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

import UIKit
import UIKit
import Alamofire
import SVProgressHUD
import Unbox

class InventoryViewController: UIViewController, UITableViewDataSource,UITableViewDelegate {

    
    @IBOutlet weak var tableView: UITableView!
    
    var mysets: [SetFromInventory] = []
    
    override func viewDidLoad() {
        super.viewDidLoad()

        print("wishlist")
        getSetsList()
    }
    func getSetsList() {
        
        
        SVProgressHUD.show()
        print ("User is \(CurrentUser.user)")
        Alamofire.request("http://mylego.local/api/InventoryApi/GetAllForUser?userId=\(CurrentUser.user)&take=20",headers: nil).responseJSON { (response:DataResponse<Any>) in
            switch response.result {
            case .success:
                SVProgressHUD.showSuccess(withStatus: "")
                if let data = response.data {
                    do {
                        var myset=[SetFromInventory]()
                        myset = try unbox(data: data)
                        print("\(myset)")
                        self.mysets = myset
                        self.tableView.reloadData()
                    } catch _ {
                        print("krepalo")                    }
                } else {
                    // javit korisniku da je nesto crklo, i da proba poslije
                }
                
            case .failure(let error):
                SVProgressHUD.showError(withStatus: "\(error.localizedDescription)")
            }
        }
    }
    func numberOfSectionsInTableView(tableView: UITableView) -> Int {
        return 1
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        print("\(mysets.count)")
        return mysets.count
    }
    
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = self.tableView.dequeueReusableCell(withIdentifier: "cell") as! CustomViewCell
        print("ucitavam");
        
        cell.idinventory.text = String(mysets[indexPath.row].Id)
        cell.name.text = mysets[indexPath.row].Ime
        cell.own.text = String(mysets[indexPath.row].ImaSetova)
        cell.fav.text = String(mysets[indexPath.row].Izgradenih)
        //cell.descript.text = mysets[indexPath.row].Opis
        cell.noOfParts.text = String(mysets[indexPath.row].DijeloviBroj)
        cell.year.text = String(mysets[indexPath.row].GodinaProizvodnje)
        cell.theme.text = String(mysets[indexPath.row].NazivTema)
        cell.instructionsInventory.text = String(mysets[indexPath.row].UputeUrl)
        
        /*
        if mysets[indexPath.row].Slike != "null" {
            let url: NSURL = NSURL(string: mysets[indexPath.row].Slike)!
            let data : NSData = NSData(contentsOf: url as URL)!
            cell.photo?.image = UIImage(data: data as Data)
        }*/
        
        return cell
    }


    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    

}
